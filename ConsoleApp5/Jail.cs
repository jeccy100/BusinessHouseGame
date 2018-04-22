using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Jail : Cell
    {

        public override string GetCellType() { return CellTypes.JAIL.ToString(); }
        public override int GetCellValue() { return -(int)CellValues.JAILFINE; }
    }
}
