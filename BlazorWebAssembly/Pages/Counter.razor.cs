using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        string fontFamily = "Verdana";

        private void IncrementCount()
        {
            currentCount++;
        }

        private void ChangeFont()
        {
            if (fontFamily == "Verdana")
                fontFamily = "Monotype Corsiva";
            else
                fontFamily = "Verdana";
        }
    }
}
