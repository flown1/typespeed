using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace TypeSpeed
{
    internal class CanvasController
    {
        private Canvas canvas;
        private List<string> wordsDisplayed = null;

        public CanvasController(Canvas canvas) {
            this.canvas = canvas;
        }
        public void drawNewWord()
        {
            TextBlock wordToDraw = new TextBlock();
            wordToDraw.Text = WordsDictionary.getRandomWord(); ;
            
            Canvas.SetLeft(wordToDraw, 10);
            Canvas.SetTop(wordToDraw, 10);
            canvas.Children.Add(wordToDraw);
        }
        
    }
}