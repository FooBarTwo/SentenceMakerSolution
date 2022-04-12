using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceMaker.Web.Services
{
    public interface ISentenceService
    {
        Task<IEnumerable<Sentence>> GetSentences();
        Task AddSentence(Sentence sentence);

        Task<IEnumerable<Word>> GetWords(WordType wordType);
    }
}
