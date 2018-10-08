using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNIM
{
    public class GameLogic
    {
        public List<int> Piles { get; set; }

        public string[] Players { get; set; } = new string[2];

        public string ActivePlayer { get; set; }

        public int RobotPileChoice()
        {
            //Daniel
            Random rnd = new Random();

            bool exit = false;
            int pileChoice = rnd.Next(0, Piles.Count + 1);
            do
            {
                if (Piles[pileChoice] == 0)
                {
                    pileChoice = rnd.Next(0, Piles.Count + 1);

                }
                else
                {
                    exit = true;
                }

            } while (!exit);
            return pileChoice;
        }

        public int RobotPieceChoice(int pile)
        {
            //Daniel
            //Added the param to this method. Add to documentation that this param did not exist before.
            Random rnd = new Random();
            int piecies = rnd.Next(1, Piles[pile] + 1);
            return piecies;
        }

        public void TakeFromPile(int pile, int pieces)
        {
            //Steven
            Piles[pile] -= pieces;
        }

        public bool IsGameOver()
        {
            bool gameOver = true;
            Piles.ForEach(pile =>
            {
                if (pile != 0)
                {
                    gameOver = false;
                }
            });

            return gameOver;
        }

        public void InitializePiles(int difficulty)
        {
            Piles = new List<int>();
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

        public void SwitchActivePlayer()
        {
            //Steven
            if (ActivePlayer == Players[0])
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
