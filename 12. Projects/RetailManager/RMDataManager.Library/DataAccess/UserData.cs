using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public UserData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<UserModel> GetUserById(string Id)
        {
            var output = _sqlDataAccess.LoadData<UserModel, dynamic>("[dbo].[spUserLookup]", new { Id = Id }, "RMData");

            return output;
        }

        public void RegisterUser(UserModel user)
        {
            _sqlDataAccess.SaveData("dbo.spUser_Register", user, "RMData");
        }
    }
}
