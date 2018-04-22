using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        private int _playerInitialAmount;

        public Player(int amountWorth)
        {
            _playerInitialAmount = amountWorth;
            TotalAmount = _playerInitialAmount;
        }
        public int PlayerId { get; set; }
        public int PlayerName
        {
            get; set;
        }
        public int InitialAmout{ get { return _playerInitialAmount; } }

        public int CurrentPosition { get; set; }
        public int NextPosition { get; set; }
        public int Steps { get; set; }

      public  int TotalAmount { get; set; }

        }
}
