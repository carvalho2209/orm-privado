using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.Framework
{
    [Serializable]
    public class LessOrEqualZeroException : Exception
    {
        public LessOrEqualZeroException() : base("Valor menor ou igual a zero não permitido.") { }
        public LessOrEqualZeroException(string message) : base(message) { }
        public LessOrEqualZeroException(string message, Exception inner) : base(message, inner) { }

        protected LessOrEqualZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

}
