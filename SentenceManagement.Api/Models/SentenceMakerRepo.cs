using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceManagement.Api.Models
{
    public class SentenceMakerRepo : ISentenceMakerRepo
    {
        private readonly AppDbContext appDbContext;

        public SentenceMakerRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Sentence> AddSentence(Sentence sententence)
        {
            var result = await appDbContext.Sentences.AddAsync(sententence);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteSentence(int sentenceId)
        {
            var result = await appDbContext.Sentences
                .FirstOrDefaultAsync(s => s.SentenceId == sentenceId);

            if (result != null)
            {
                appDbContext.Sentences.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Sentence> GetSentence(int sentenceId)
        {
            return await appDbContext.Sentences.FirstOrDefaultAsync(s => s.SentenceId == sentenceId);
        }

        public async Task<IEnumerable<Sentence>> GetSentences()
        {
            return await appDbContext.Sentences.ToListAsync<Sentence>();
        }

        public async Task<Sentence> UpdateSentence(Sentence sententence)
        {
            var result = await appDbContext.Sentences.FirstOrDefaultAsync(s => s.SentenceId == sententence.SentenceId);

            if (result != null)
            {
                result.SentenceId = sententence.SentenceId;
                result.Content = sententence.Content;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public Task<IEnumerable<Word>> GetWords(WordType wordType)
        {
            throw new NotImplementedException();
        }

    }
}
