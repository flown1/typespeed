using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TypeSpeed
{
    class Config
    {
        public double CANVAS_WIDTH;
        public double CANVAS_HEIGHT;
        
        public static int LOOP_INTERVAL = 100;
        public static int MOVE_RIGHT_STEP = 5;


        public static int INIT_WORD_ADDING_INTERVAL = 2000;

        public Config() {
        }
        public void setCanvasConfig(Canvas canvas)
        {
            this.CANVAS_WIDTH = canvas.ActualWidth;
            this.CANVAS_HEIGHT = canvas.ActualHeight;
        }
        public double getCanvasHeight()
        {
            return CANVAS_HEIGHT;
        }
        public double getCanvasWidth()
        {
            return CANVAS_WIDTH;
        }
    }
}
