using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Treasure : Cell
    {

        public override string GetCellType() { return CellTypes.TREASURE.ToString(); }
        // values is worth here
        public override int GetCellValue() { return (int)CellValues.TREASUREVALUE; }
    }
}
