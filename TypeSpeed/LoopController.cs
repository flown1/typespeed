using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TypeSpeed
{
    public class LoopController
    {
        private CanvasController canvasController;

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
            Console.WriteLine("Tick");
            canvasController.moveWordsRight();
        }
    }
}