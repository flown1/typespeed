using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TypeSpeed
{
    public class Config
    {
        public static int LOOP_INTERVAL = 50;
        public static int MOVE_RIGHT_STEP = 1;

        public static int INIT_LIVES = 10;

        public static int INIT_WORD_ADDING_INTERVAL = 2000;
        public static double WORDS_ADDING_INTERVAL_DECREMENTATION_MULTIPLAIER = 0.04;
        public int currentWordsAddingInterval = INIT_WORD_ADDING_INTERVAL;

        public static int INIT_MOVE_TIME_INTERVAL = 50;
        public int currentWordsMoveInterval = INIT_MOVE_TIME_INTERVAL; 

        
        public static int REFRESHING_SCORE_TIME_INTERVAL = 200;
        public static double WORDS_MOVING_INTERVAL_DECREMENTATION_MULTIPLAIER = 0.2;
        public static int MIN_FONT_SIZE = 14;
        public static int MAX_FONT_SIZE = 19;
        public bool GAME_ON;

        public Config() {
            GAME_ON = true;
        }
        public void setCurrentWordsAddingInterval(int val) {
            this.currentWordsAddingInterval = val;
        }
        
        public int getCurrentMoveTimeInterval()
        {
            return currentWordsMoveInterval;
        }
        public void setCurrentMoveTimeInterval(int val)
        {
            currentWordsMoveInterval = val;
        }
        
    }
}
