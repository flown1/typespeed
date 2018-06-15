using System;

namespace TypeSpeed
{
    public class WordsDictionary
    {
        private static string[] WORDS_BASE = { "jeronimo", "ala", "kot", "dog", "hair", "pizza", "coffee" };

        public static string getRandomWord()
        {
            Random random = new Random();
            return WORDS_BASE[random.Next(0, WORDS_BASE.Length)];
        }
    }
}