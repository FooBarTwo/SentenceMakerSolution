using Microsoft.AspNetCore.Components;
using SentenceMaker.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceMaker.Web.Pages
{
    public partial class SentenceBuilder
    {
        Sentence newSentence = new Sentence();

        [Inject]
        public ISentenceService SentenceService { get; set; }

        public IEnumerable<Sentence> Sentences { get; set; }

        protected async Task SaveSentence()
        {
            //Sentences = (await SentenceService.GetSentences()).ToList();
            Sentence newSen = newSentence;
            await SentenceService.AddSentence(newSen);
        }
    }
}
