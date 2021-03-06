﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TypeSpeed
{
    public class LoopController
    {
        private CanvasController canvasController;
        private int WORDS_ADD_INTERVAL;

        public LoopController(CanvasController canvasController) {
            this.canvasController = canvasController;
        }
        public async Task startLoop(Config config, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await makeCanvasMoveWords();
                await Task.Delay(config.currentWordsMoveInterval);
            };
        }

        private async Task makeCanvasMoveWords()
        {
            canvasController.moveWordsRight();
        }

        public async Task addNewWordLoop(Config config, CancellationToken cancellationToken)
        {
            while (true) {
                cancellationToken.ThrowIfCancellationRequested();
                await makeCanvasAddNewWord();
                await Task.Delay(config.currentWordsAddingInterval);
            }
        }

        private async Task makeCanvasAddNewWord()
        {
            canvasController.drawNewWord();
        }
        
        public async Task scoreUpdater(Config config, MainWindow mainWindow, PlayerInfo playerInfo, CancellationToken cancellationToken)
        {
            while (true){
                cancellationToken.ThrowIfCancellationRequested();
                await updateScore(mainWindow, playerInfo);
                await Task.Delay(Config.REFRESHING_SCORE_TIME_INTERVAL);
            }
        }
        
        private async Task updateScore(MainWindow mainWindow, PlayerInfo playerInfo)
        {
            mainWindow.score.Text = playerInfo.getScore().ToString();
        }
    }
}