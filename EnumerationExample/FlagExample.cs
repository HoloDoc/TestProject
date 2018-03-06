using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationExample
{
    [Flags]
    public enum FlagExamples
    {
        NONE = 0,
        RED = 1,
        GREEN = 2,
        fdsafds = 4,
        other = 8
    }
}
