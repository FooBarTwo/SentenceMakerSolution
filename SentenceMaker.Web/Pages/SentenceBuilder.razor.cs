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
        public IEnumerable<Word> Words { get; set; }

        protected async Task SaveSentence()
        {
            Sentence newSen = newSentence;
            await SentenceService.AddSentence(newSen);
            newSentence.Content = "";
        }


        // ****** Words List *****
        protected override async Task OnInitializedAsync()
        {
            WordType wordType = WordType.Noun;
            //Sentences = (await SentenceService.GetSentences()).ToList();
            Words = (await SentenceService.GetWords(wordType)).ToList();
        }
    }
}
