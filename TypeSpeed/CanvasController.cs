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

        
        public CanvasController(Canvas canvas) {
            this.canvas = canvas;
            wordsDisplayed = new List<Word>();
        }
        public void drawNewWord()
        {
            Word newWord = new Word();
            //TextBlock newWord = new TextBlock();
            Canvas.SetLeft(newWord, 10);
            Canvas.SetTop(newWord, 10 );
            canvas.Children.Add(newWord);

            wordsDisplayed.Add(newWord);
        }
        
        public void moveWordsRight() {
            
            foreach (Word word in wordsDisplayed) {
                word.setPosX(word.getPosX() + MainWindow.MOVE_RIGHT_STEP);
                Canvas.SetLeft(word, word.getPosX());
            }
        }

        public void checkIfHit(string text)
        {
            List<Word> wordsToDelete = new List<Word>();
            foreach (Word word in wordsDisplayed) {
                if (word.Text.Equals(text)) {
                    wordsToDelete.Add(word);
                }
            }
            deleteWords(wordsToDelete);
        }

        private void deleteWords(List<Word> wordsToDelete)
        {
            foreach (Word word in wordsToDelete) {
                canvas.Children.Remove(word);
                wordsToDelete.Remove(word);
            }
        }
    }
}