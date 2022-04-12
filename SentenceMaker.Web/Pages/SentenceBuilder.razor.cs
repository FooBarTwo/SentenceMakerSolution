using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using SentenceMaker.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private InputTextArea inputTextEditor;
        protected async Task SaveSentence()
        {
            if (newSentence.Content == null)
            {
                return;
            }

            if (newSentence.Content.Trim() == "" || newSentence.Content.Trim() == ".")
            {
                newSentence.Content = "";
                nWordCount = 0;
                lblNumWords = nWordCount.ToString();
                return;
            }

            Sentence newSen = newSentence;
            await SentenceService.AddSentence(newSen);
            newSentence.Content = "";
            nWordCount = 0;
            lblNumWords = nWordCount.ToString();
        }

        protected async Task ClearEditor()
        {
            newSentence.Content = "";
            nWordCount = 0;
            lblNumWords = nWordCount.ToString();
        }

        // Add select WordType:
        protected async Task SelectWordType(ChangeEventArgs e)
        {
            WordType wordType = GetWordType(int.Parse(e.Value.ToString()));

            Words = await SentenceService.GetWords(wordType);
            lstWords = Words.ToList<Word>();
            sWordListTitle = wordType.ToString() + "s";
        }

        private WordType GetWordType(int nWordType)
        {
            WordType wordType;

            switch (nWordType)
            {
                case 0:
                    wordType = WordType.Noun;
                    break;
                case 1:
                    wordType = WordType.Verb;
                    break;
                case 2:
                    wordType = WordType.Adjective;
                    break;
                case 3:
                    wordType = WordType.Adverb;
                    break;
                case 4:
                    wordType = WordType.Pronoun;
                    break;
                case 5:
                    wordType = WordType.Preposition;
                    break;
                case 6:
                    wordType = WordType.Conjunction;
                    break;
                case 7:
                    wordType = WordType.Determiner;
                    break;
                case 8:
                    wordType = WordType.Exclamation;
                    break;
                case 9:
                    wordType = WordType.Noun;
                    break;
                default:
                    wordType = WordType.Noun;
                    break;
            }

            return wordType;
        }

        string strWordUi = "";
        static int nWordCount = 0;
        string lblNumWords = "0";
        string sWordListTitle = "Nouns";
        protected void AddWordToEditor(string sBtnTxt)
        {
            if (nWordCount == 0)
            {
                newSentence.Content = "";
            }

            newSentence.Content += sBtnTxt.ToLower() + " ";
            nWordCount++;

            // Format sentence correctly:
            newSentence.Content = CapitalizeFirst(newSentence.Content);
            lblNumWords = nWordCount.ToString();
            //lblNumWords.InnerText = nWordCount.ToString();
        }

        protected void AddFullStopToEditor()
        {
            //if (newSentence.Content != null && newSentence.Content.Trim() == "")
            //    return;

            if (nWordCount == 0)
            {
                //newSentence.Content = "";
                return;
            }

            newSentence.Content = newSentence.Content.Trim();

            newSentence.Content += ".  ";
            //nWordCount++;

            // Format sentence correctly:
            newSentence.Content = CapitalizeFirst(newSentence.Content);
            lblNumWords = nWordCount.ToString();
            //lblNumWords.InnerText = nWordCount.ToString();
        }

        public string CapitalizeFirst(string s)
        {
            bool IsNewSentense = true;
            var result = new StringBuilder(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(s[i]))
                {
                    result.Append(char.ToUpper(s[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append(s[i]);

                if (s[i] == '!' || s[i] == '?' || s[i] == '.')
                {
                    IsNewSentense = true;
                }
            }

            string newString = result.ToString();

            //if (IsNewSentense)
            //{
            //    newString = newString;
            //}

            return newString;
        }

        WordType wordType;
        List<Word> lstWords = new List<Word>();
        private ElementReference txtInputTextEditor;
        // ****** Words List *****
        protected override async Task OnInitializedAsync()
        {
            //newSentence.Content = "Sample Sentence. Select a WORD TYPE from the Word Types drop down list and then select a WORD of your choice from the Word List.";
            nWordCount = 0;

            wordType = WordType.Noun;
            Words = await SentenceService.GetWords(wordType);
            lstWords = Words.ToList<Word>();
        }

    }
}
