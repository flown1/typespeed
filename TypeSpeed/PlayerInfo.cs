using System;

namespace TypeSpeed
{
    public class PlayerInfo
    {
        private int lives;
        private int score;
        public PlayerInfo(int iNIT_LIVES)
        {
            this.score = 0;
            this.lives = iNIT_LIVES;
        }
        public void looseLife(int howMany) {
            lives -= howMany;
        }
        public int getLives() {
            return lives;
        }

        public int getScore()
        {
            return score;
        }
        public void addPoints(int points) {
            score += points;
        }
    }
}