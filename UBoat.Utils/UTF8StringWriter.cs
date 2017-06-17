using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils
{
    /// <summary>
    /// Completely BULLSHIT class because .NET does not supply a simple facility to set the encoding on a StringWriter.
    /// </summary>
    public class UTF8StringWriter : StringWriter
    {
        public UTF8StringWriter()
            : base()
        {
        }
        public UTF8StringWriter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }
        public UTF8StringWriter(StringBuilder sb)
            : base(sb)
        {
        }
        public UTF8StringWriter(StringBuilder sb, IFormatProvider formatProvider)
            : base(sb, formatProvider)
        {
        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
