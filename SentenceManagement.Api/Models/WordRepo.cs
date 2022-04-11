using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceManagement.Api.Models
{
    public class WordRepo : IWordRepo
    {
        private readonly AppDbContext appDbContext;

        public WordRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Word>> GetWords(WordType pWordType)
        {
            var resultList = await appDbContext.Words.ToListAsync<Word>();
            var result = resultList.Where<Word>(w => w.TypeOfWord == pWordType);
            return result;
        }

    }
}
