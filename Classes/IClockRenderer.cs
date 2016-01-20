using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public interface IClockRenderer
    {
        void Reset();
        void Write(char lamp);
        void WriteLine();
        string Render();
    }
}
