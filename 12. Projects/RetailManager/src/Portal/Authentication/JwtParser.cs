using System.Security.Claims;
using System.Text.Json;

namespace Portal.Authentication
{
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];

            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs is not null)
            {
                ExtractRolesFromJWT(claims, keyValuePairs);

                claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            }

            return claims;
        }

        private static void ExtractRolesFromJWT(List<Claim> claims, Dictionary<string, object> keyValuePairs)
        {
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object? roles);

            if (roles is not null)
            {
                var parseRoles = roles.ToString()?.Trim().TrimStart('[').TrimEnd(']').Split(',');

                if (parseRoles?.Length > 1)
                {
                    foreach (var parseRole in parseRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parseRole.Trim('"')));
                    }
                }
                else if (parseRoles is not null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, parseRoles[0]));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
                default:
                    break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
