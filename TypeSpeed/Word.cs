using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TypeSpeed
{
    public class Word : TextBlock
    {
        private int posX, posY;
        private Color color;

        public Word(): base() {

            Random random = new Random();
            
            this.posX = 0;
            this.posY = random.Next(0, 400/*Convert.ToInt32(MainWindow.config.getCanvasHeight()*/);
            this.color = new Color();

            base.Text = WordsDictionary.getRandomWord();
        }

        public int getPosX() { return posX; }
        public void setPosX(int newPosX) { this.posX = newPosX; }
        public int getPosY() { return posY; }
        public void setPosY(int newPosY) { this.posY = newPosY; }


    }
}