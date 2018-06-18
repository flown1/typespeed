using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TypeSpeed
{
    public class CanvasController
    {
        private Canvas canvas;
        private List<Word> wordsDisplayed;
        private PlayerInfo playerInfo;
        private Config config;
        private MainWindow handlerToMainWindow;
        private CancellationTokenSource startLoopCancellationToken;
        private CancellationTokenSource scoreUpdaterCancellationToken;
        private CancellationTokenSource addNewWordCancellationToken;

        public CanvasController(MainWindow window, Canvas canvas, PlayerInfo playerInfo, Config config) {
            this.canvas = canvas;
            wordsDisplayed = new List<Word>();
            this.playerInfo = playerInfo;
            this.config = config;
            this.handlerToMainWindow = window;
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

                if (word.getPosX() < 700)
                {
                    word.setPosX(word.getPosX() + Config.MOVE_RIGHT_STEP);
                    Canvas.SetLeft(word, word.getPosX());

                    if (word.getPosX() == 550)
                    {
                        word.setForeground(ColorPalette.RED);
                    }
                    else if (word.getPosX() == 400) {
                        word.setForeground(ColorPalette.YELLOW);
                    }
                }
                else
                {
                    wordMadeItToTheEnd(word);
                }
            }
        }

        public void bindCancellationTokens(CancellationTokenSource startLoopCancellationToken, CancellationTokenSource scoreUpdaterCancellationToken, CancellationTokenSource addNewWordCancellationToken)
        {
            this.startLoopCancellationToken = startLoopCancellationToken;
            this.scoreUpdaterCancellationToken = scoreUpdaterCancellationToken;
            this.addNewWordCancellationToken = addNewWordCancellationToken;
        }

        private void wordMadeItToTheEnd(Word word)
        {
            deleteWord(word);
            config.GAME_ON = false;
            handlerToMainWindow.buttonRestart.IsEnabled = true;
            
            scoreUpdaterCancellationToken.Cancel();
            startLoopCancellationToken.Cancel();
            addNewWordCancellationToken.Cancel();
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

        public void clearEverything()
        {

            foreach (Word word in wordsDisplayed) {
                canvas.Children.Remove(word);
            }
            wordsDisplayed.Clear();
            config.currentWordsAddingInterval = Config.INIT_WORD_ADDING_INTERVAL;
            config.currentWordsMoveInterval = Config.INIT_MOVE_TIME_INTERVAL;
            playerInfo.loosePoints(playerInfo.getScore());
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