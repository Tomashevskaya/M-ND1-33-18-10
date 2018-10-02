using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Player.Exceptions
{
    [Serializable]
    public class PlayerException : Exception
    {
        public PlayerException()
        {
        }

        public PlayerException(string message) : base(message)
        {
        }

        public PlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
