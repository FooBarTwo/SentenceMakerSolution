using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WordManagement.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace SentenceMaker.Web.Services
{
    public class SentenceService : ISentenceService
    {
        private readonly HttpClient httpClient;

        public SentenceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddSentence(Sentence sentence)
        {
            var result = await httpClient.PostAsJsonAsync<Sentence>("api/sentences", sentence, null);
        }

        public async Task<IEnumerable<Sentence>> GetSentences()
        {
            var result = await httpClient.GetFromJsonAsync<Sentence[]>("api/sentences");
            return result;
        }

        public async Task<IEnumerable<Word>> GetWords(WordType wordType)
        {
            int nWordType = (int)wordType;
            var result = await httpClient.GetFromJsonAsync<Word[]>("api/sentences/words/" + nWordType);
            return result;
        }
    }
}
