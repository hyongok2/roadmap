using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AnswerBot.Services;

public class ChatGPTService : IChatService
{
    private readonly IConfiguration _configuration;

    public ChatGPTService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<string> GetAnswer(string question)
    {
        // Replace with your OpenAI API key
        string apiKey = _configuration.GetValue<string>("apiKey");

        // Define the request parameters
        string model = _configuration.GetValue<string>("chatGPTModel");
        int maxTokens = _configuration.GetValue<int>("maxTokens");

        // Construct the API URL
        string url = $"https://api.openai.com/v1/completions";

        // Create the HTTP client
        HttpClient client = new HttpClient();

        // Add the API key to the request headers
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

        // Define the request payload
        var payload = new
        {
            model = model,
            prompt = question,
            max_tokens = maxTokens,
            n = 1,
            temperature = 1
        };

        // Serialize the request payload to JSON
        var content = new StringContent(JsonConvert.SerializeObject(payload));
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        // Send the API request and get the response
        var response = await client.PostAsync(url, content);
        var responseText = await response.Content.ReadAsStringAsync();

        // Deserialize the response to a dynamic object
        dynamic responseData = JsonConvert.DeserializeObject(responseText);

        // Extract the generated text from the response
        return responseData.choices[0].text;
    }

}
