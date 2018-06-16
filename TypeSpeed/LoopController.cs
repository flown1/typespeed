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
        public async Task startLoop(int interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                await makeCanvasMoveWords();
                await Task.Delay(interval, cancellationToken);
            };
        }

        private async Task makeCanvasMoveWords()
        {
            //Console.WriteLine("Tick");
            canvasController.moveWordsRight();
        }

        public async void addNewWordWithInitInterval(int INIT_WORD_ADDING_INTERVAL)
        {
            this.WORDS_ADD_INTERVAL = INIT_WORD_ADDING_INTERVAL;

            while (true) {
                await makeCanvasAddNewWord();
                await Task.Delay(WORDS_ADD_INTERVAL);
            }
        }

        private async Task makeCanvasAddNewWord()
        {
            canvasController.drawNewWord();
        }
    }
}