using System;
using System.Collections.Generic;
using System.Text;

namespace WordManagement.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public WordType TypeOfWord { get; set; }
        public string Descrip { get; set; }
    }
}
