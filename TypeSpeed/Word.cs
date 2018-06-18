using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TypeSpeed
{
    public class Word : TextBlock
    {
        private int posX, posY, width, height;
        
        

        public Word(): base() {
            Random random = new Random();
            
            this.posX = -30;
            this.posY = random.Next(0, 390/*Convert.ToInt32(MainWindow.config.getCanvasHeight()*/);
            
            base.Foreground = ColorPalette.GREEN;
            base.Text = WordsDictionary.getRandomWord();
            base.FontSize = random.Next(Config.MIN_FONT_SIZE, Config.MAX_FONT_SIZE);
        }

        public int getPosX() { return posX; }
        public void setPosX(int newPosX) { this.posX = newPosX; }
        public int getPosY() { return posY; }
        public void setPosY(int newPosY) { this.posY = newPosY; }

        public void setForeground(SolidColorBrush color) {
            base.Foreground = color;
        }
        

    }
}