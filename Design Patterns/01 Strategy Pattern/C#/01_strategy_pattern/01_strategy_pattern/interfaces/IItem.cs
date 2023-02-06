using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_strategy_pattern.interfaces
{
    internal interface IItem
    {
        Guid Identifier { get; }
        string Name { get; }

    }
}
