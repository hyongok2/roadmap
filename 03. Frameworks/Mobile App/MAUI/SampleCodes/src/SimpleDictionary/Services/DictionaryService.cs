using Newtonsoft.Json;
using SimpleDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionary.Services
{
    public class DictionaryService : IDictionaryService
    {
        public async Task<Stream> GetAudioStream(string url)
        {
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync(url);

                Stream stream = await response.Content.ReadAsStreamAsync();

                return stream;
            }
            catch (Exception)
            {

               return null;
            }

        }

        public async Task<List<DictionaryModel>> GetInformation(string key)
        {
            if(string.IsNullOrEmpty(key)) return null;

            var httpClient = new HttpClient();
            var url = "https://api.dictionaryapi.dev/api/v2/entries/en/" + key;

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<DictionaryModel>>();
            }
             
            return null;
        }


    }
}
