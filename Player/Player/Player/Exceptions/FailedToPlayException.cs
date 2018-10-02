using Player.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Player.Exceptions
{
    [Serializable]
    public class FailedToPlayException: PlayerException
    {
        public Song Song { get; set; }

        public FailedToPlayException()
        {
        }

        public FailedToPlayException(string message) : base(message)
        {
        }

        public FailedToPlayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailedToPlayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
