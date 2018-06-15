using System.Windows.Controls;
using System.Windows.Media;

namespace TypeSpeed
{
    public class Word : TextBlock
    {
        private int posX, posY;
        private Color color;

        public Word(): base() {

            this.posX = 10;
            this.posY = 10;
            this.color = new Color();

            base.Text = WordsDictionary.getRandomWord();
        }

        public int getPosX() { return posX; }
        public void setPosX(int newPosX) { this.posX = newPosX; }
        public int getPosY() { return posY; }
        public void setPosY(int newPosY) { this.posY = newPosY; }


    }
}