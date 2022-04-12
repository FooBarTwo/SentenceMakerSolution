using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

        string strWordUi = "";
        protected void AddWordToEditor(string sBtnTxt)
        {
            newSentence.Content += sBtnTxt;
        }

        WordType wordType;
        List<Word> lstWords = new List<Word>();
        // ****** Words List *****
        protected override async Task OnInitializedAsync()
        {
            wordType = WordType.Noun;
            Words = await SentenceService.GetWords(wordType);
            lstWords = Words.ToList<Word>();
        }
    }
}
