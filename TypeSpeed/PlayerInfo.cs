using System;

namespace TypeSpeed
{
    public class PlayerInfo
    {
        private int score;
        public PlayerInfo()
        {
            this.score = 0;
        }
        public int getScore()
        {
            return score;
        }
        public void addPoints(int points) {
            score += points;
        }
        public void loosePoints(int points) {
            score -= points;

        }
    }
}