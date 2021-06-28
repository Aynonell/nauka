using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task7
{
    public class Task07
    {
        Dictionary<char, int> RomanLettersValues;
        public Task07()
        {
            RomanLettersValues = new Dictionary<char, int>();
            RomanLettersValues.Add('I', 1);
            RomanLettersValues.Add('V', 5);
            RomanLettersValues.Add('X', 10);
            RomanLettersValues.Add('L', 50);
            RomanLettersValues.Add('C', 100);
            RomanLettersValues.Add('D', 500);
            RomanLettersValues.Add('M', 1000);
        }
        public int  RomanToInt(string Roman)
        {

            return -1;
        }
    }
}
