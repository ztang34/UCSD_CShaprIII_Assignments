using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class PointListChangedEventArgs: EventArgs
    {
        public enum PointListChangedOperations
        {
            Unknown = 0,
            Add,
            Remove,
            Insert,
            Clear,
            Update
        }

        public PointListChangedOperations Operation { get; set; } = PointListChangedOperations.Unknown;

        public PointListChangedEventArgs(PointListChangedOperations op)
        {
            Operation = op;
        }
    }
}
