using System;
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
                await makeCanvasMoveWords();
                await Task.Delay(config.currentWordsMoveInterval, cancellationToken);
            };
        }

        private async Task makeCanvasMoveWords()
        {
            //Console.WriteLine("Tick");
            canvasController.moveWordsRight();
        }

        public async void addNewWordWithInitInterval(Config config)
        {
            while (true) {
                await makeCanvasAddNewWord();
                await Task.Delay(config.currentWordsAddingInterval);
            }
        }

        private async Task makeCanvasAddNewWord()
        {
            canvasController.drawNewWord();
        }
        
        public async Task scoreAndLivesUpdater(Config config, MainWindow mainWindow, PlayerInfo playerInfo)
        {
            while (true){
                await updateScore(mainWindow, playerInfo);
                await updateLives(mainWindow, playerInfo);

                await Task.Delay(Config.REFRESHING_SCORE_TIME_INTERVAL);
            }
        }

        private async Task updateLives(MainWindow mainWindow, PlayerInfo playerInfo)
        {
            mainWindow.lives.Text = playerInfo.getLives().ToString();
        }

        private async Task updateScore(MainWindow mainWindow, PlayerInfo playerInfo)
        {
            mainWindow.score.Text = playerInfo.getScore().ToString();
        }
    }
}