using SimpleDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionary.Services
{
    public interface IDictionaryService
    {
        Task<List<DictionaryModel>> GetInformation(string key);
        Task<Stream> GetAudioStream(string url);
    }
}
