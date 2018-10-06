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
            //Furman
            throw new NotImplementedException();
        }

        public void InitializePiles(int difficulty)
        {
            //Furman
            throw new NotImplementedException();
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
