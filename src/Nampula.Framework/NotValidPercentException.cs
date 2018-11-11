using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.Framework
{
    [Serializable]
    public class NotValidPercentException : Exception
    {
        public NotValidPercentException() : base("O Valor não é um parcentual válido!") { }
        public NotValidPercentException(string message) : base(message) { }
        public NotValidPercentException(string message, Exception inner) : base(message, inner) { }

        protected NotValidPercentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

}
