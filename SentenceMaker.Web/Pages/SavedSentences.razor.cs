using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManagement.Models;

namespace SentenceMaker.Web.Pages
{
    public partial class SavedSentences
    {
        public IEnumerable<Sentence> Sentences { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Thread.Sleep(5000);
            await Task.Run(LoadSentences);
            //return base.OnInitializedAsync();
        }

        private void LoadSentences()
        {
            // Artificial delay:
            System.Threading.Thread.Sleep(400);

            Sentence s1 = new Sentence { SentenceId = 1, Content = "Hello World!" };
            Sentence s2 = new Sentence { SentenceId = 2, Content = "Goodbye World." };
            Sentence s3 = new Sentence { SentenceId = 3, Content = "Hello Summer." };
            Sentence s4 = new Sentence { SentenceId = 4, Content = "Whatever you say is only you're opinion." };
            Sentence s5 = new Sentence { SentenceId = 5, Content = "When comes and the sun chaseth the darkness away." };
            Sentence s6 = new Sentence { SentenceId = 6, Content = "When the blueberry sings and the mocking bird hums." };
            Sentence s7 = new Sentence { SentenceId = 7, Content = "Just another sample sentence." };
            Sentence s8 = new Sentence { SentenceId = 8, Content = "A sample sentence." };
            Sentence s9 = new Sentence { SentenceId = 9, Content = "Yet another sample sentence." };
            Sentence s10 = new Sentence { SentenceId = 10, Content = "This is sample sentence number 10." };

            Sentences = new List<Sentence> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
        }
    }
}
