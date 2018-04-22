using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Empty : Cell
    {

        public override string GetCellType() { return CellTypes.EMPTY.ToString(); }
        public override int GetCellValue() { return 0; }
    }
}
