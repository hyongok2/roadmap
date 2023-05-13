using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionary.Models
{
    public class Definition
    {
        [JsonProperty("definition")]
        public string definition { get; set; }
        [JsonProperty("synonyms")]
        public List<object> Synonyms { get; set; }
        [JsonProperty("antonyms")]
        public List<object> Antonyms { get; set; }
        [JsonProperty("example")]
        public string Example { get; set; }
    }

    public class License
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Meaning
    {
        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }
        [JsonProperty("definitions")]
        public List<Definition> Definitions { get; set; }
        [JsonProperty("synonyms")]
        public List<string> Synonyms { get; set; }
        [JsonProperty("antonyms")]
        public List<object> Antonyms { get; set; }
    }

    public class Phonetic
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("audio")]
        public string Audio { get; set; }
        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }
        [JsonProperty("license")]
        public License License { get; set; }
    }

    public class DictionaryModel
    {
        [JsonProperty("word")]
        public string Word { get; set; }
        [JsonProperty("phonetic")]
        public string Phonetic { get; set; }
        [JsonProperty("phonetics")]
        public List<Phonetic> Phonetics { get; set; }
        [JsonProperty("meanings")]
        public List<Meaning> Meanings { get; set; }
        [JsonProperty("license")]
        public License License { get; set; }
        [JsonProperty("sourceUrls")]
        public List<string> SourceUrls { get; set; }
    }
}
