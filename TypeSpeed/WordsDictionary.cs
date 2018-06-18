using System;

namespace TypeSpeed
{
    public class WordsDictionary
    {
        private static string[] WORDS_BASE = {  "jeronimo", "ala", "cat", "dog", "hair",
                                                "pizza", "coffee", "word", "random",
                                                "variable", "silver","giraffe", "notebook",
                                                "crocodile", "gazelle", "accident", "beer",
                                                "project", "speed", "trousers", "guitar",
                                                "amplifier", "forest", "chair", "patch",
                                                "keyboard", "sweter","pillow", "sofa"};

        public static string getRandomWord()
        {
            Random random = new Random();
            return WORDS_BASE[random.Next(0, WORDS_BASE.Length)];
        }
    }
}