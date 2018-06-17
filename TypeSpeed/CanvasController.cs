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
        private Config config;

        public CanvasController(Canvas canvas, PlayerInfo playerInfo, Config config) {
            this.canvas = canvas;
            wordsDisplayed = new List<Word>();
            this.playerInfo = playerInfo;
            this.config = config;
        }
        public void drawNewWord()
        {
            Word newWord = new Word();
            //TextBlock newWord = new TextBlock();
            Canvas.SetLeft(newWord, newWord.getPosX());
            Console.WriteLine(newWord.Height);
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
            config.GAME_ON = false;
        }

        public void checkIfHit(string text)
        {
            List<Word> wordsToDelete = new List<Word>();
            foreach (Word word in wordsDisplayed) {
                if (word.Text.Equals(text)) {
                    wordsToDelete.Add(word);
                    playerInfo.addPoints(1);
                }
            }
            if (wordsToDelete.Count > 0)
            {
                deleteWords(wordsToDelete);
                makeGameHarder();
            }
            else {
                playerInfo.loosePoints(1);
            }
        }

        private void makeGameHarder()
        {
            config.setCurrentWordsAddingInterval(config.currentWordsAddingInterval - (int)(config.currentWordsAddingInterval * Config.WORDS_ADDING_INTERVAL_DECREMENTATION_MULTIPLAIER));
            config.setCurrentMoveTimeInterval(config.currentWordsMoveInterval - (int)(config.currentWordsMoveInterval * Config.WORDS_MOVING_INTERVAL_DECREMENTATION_MULTIPLAIER));
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