using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TypeSpeed
{
    public class CanvasController
    {
        private Canvas canvas;
        private List<Word> wordsDisplayed;
        private PlayerInfo playerInfo;
        
        public CanvasController(Canvas canvas, PlayerInfo playerInfo) {
            this.canvas = canvas;
            wordsDisplayed = new List<Word>();
            this.playerInfo = playerInfo;
        }
        public void drawNewWord()
        {
            Word newWord = new Word();
            //TextBlock newWord = new TextBlock();
            Canvas.SetLeft(newWord, newWord.getPosX());
            Canvas.SetTop(newWord, newWord.getPosY());
            canvas.Children.Add(newWord);

            wordsDisplayed.Add(newWord);
        }
        
        public void moveWordsRight() {
            foreach (Word word in wordsDisplayed) {
                if (word.getPosX() < 800)
                {
                    word.setPosX(word.getPosX() + Config.MOVE_RIGHT_STEP);
                    Canvas.SetLeft(word, word.getPosX());

                    if (word.getPosX() == 600)
                    {
                        word.setForeground(ColorPalette.RED);
                    }
                    else if (word.getPosX() == 450) {
                        word.setForeground(ColorPalette.YELLOW);
                    }
                }
                else
                {
                    wordMadeItToTheEnd(word);
                }
            }
        }

        private void wordMadeItToTheEnd(Word word)
        {
            deleteWord(word);
            playerInfo.looseLife(1);
        }

        public void checkIfHit(string text)
        {
            List<Word> wordsToDelete = new List<Word>();
            foreach (Word word in wordsDisplayed) {
                if (word.Text.Equals(text)) {
                    wordsToDelete.Add(word);
                }
            }
            if (wordsToDelete.Count > 0)
            {
                deleteWords(wordsToDelete);
            }
        }

        private void deleteWords(List<Word> wordsToDelete)
        {
            try
            {
                foreach (Word word in wordsToDelete)
                {
                    deleteWord(word);
                }
            }
            catch (Exception e) {
                Console.WriteLine("ERROR! " + e.Message);
            }
        }

        private void deleteWord(Word word)
        {
            canvas.Children.Remove(word);
            wordsDisplayed.Remove(word);
        }
    }
}