using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.WebHawk.Controller.Integration.SequenceTranslators
{
    public static class SequenceTranslatorFactory
    {
        public static ISequenceTranslator GetSequenceTranslator(SequenceTranslationType translationType)
        {
            switch (translationType)
            {
                case SequenceTranslationType.XSLT:
                    return new XSLTSequenceTranslator();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
