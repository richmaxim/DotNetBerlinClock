using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public class TextClockRenderer : IClockRenderer
    {
        const int StringBufferLength = 33;

        private string _newLine;
        private StringBuilder _builder = new StringBuilder(StringBufferLength);

        public void Reset()
        {
            _builder.Length = 0;
        }

        public TextClockRenderer(string newLine)
        {
            _newLine = newLine;
        }

        public void Write(char lamp)
        {
            _builder.Append(lamp);
        }

        public void WriteLine()
        {
            _builder.Append(_newLine);
        }

        public string Render()
        {
            return _builder.ToString();
        }
    }
}
