using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceManagement.Api.Models
{
    public interface ISentenceMakerRepo
    {
        Task<IEnumerable<Sentence>> GetSentences();
        Task<Sentence> GetSentence(int sentenceId);
        Task<Sentence> AddSentence(Sentence sententence);
        Task<Sentence> UpdateSentence(Sentence sententence);
        void DeleteSentence(int sentenceId);
    }
}
