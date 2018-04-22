using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Hotel : Cell
    {

        public override string GetCellType() { return CellTypes.HOTEL.ToString(); }
        //values is worth here
        public override int GetCellValue() { return (int)CellValues.HOTELVALUE; ; }

        public int Rent { get { return (int)CellValues.HOTELRENT; } }
        public bool IsOwned { get; set; } 
        public Player OwnedBy { get; set; }
    }

}
