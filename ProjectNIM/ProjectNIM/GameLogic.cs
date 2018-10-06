using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNIM
{
    class GameLogic
    {
        public List<int> Piles { get; set; }

        public string[] Players { get; set; }

        public string ActivePlayer { get; set; }

        public int RobotPileChoice()
        {
            //Daniel
            throw new NotImplementedException();
        }

        public int RobotPieceChoice()
        {
            //Daniel
            throw new NotImplementedException();
        }

        public void TakeFromPile(int pile, int pieces)
        {
            //Steven
            Piles[pile] -= pieces;
        }

        public bool IsGameOver()
        {
            bool gameOver = true;
            Piles.ForEach(pile => {
                if (pile != 0)
                {
                    gameOver = false;
                }
            });

            return gameOver;
        }

        public void InitializePiles(int difficulty)
        {
            switch (difficulty)
            {
                case 0:
                    Piles.Add(3);
                    Piles.Add(3);
                    break;
                case 1:
                    Piles.Add(2);
                    Piles.Add(5);
                    Piles.Add(7);
                    break;
                case 2:
                    Piles.Add(2);
                    Piles.Add(3);
                    Piles.Add(8);
                    Piles.Add(9);
                    break;
            }
        }

        private void SwitchActivePlayer()
        {
            //Steven
            if(ActivePlayer == Players[0])
            {
                ActivePlayer = Players[1];
            }
            else
            {
                ActivePlayer = Players[0];
            }
        }


    }
}
