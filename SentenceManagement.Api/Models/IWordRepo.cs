using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceManagement.Api.Models
{
    public interface IWordRepo
    {
        //Task<IEnumerable<Sentence>> GetSentences();
        Task<IEnumerable<Word>> GetWords(WordType pWordType);
    }
}
