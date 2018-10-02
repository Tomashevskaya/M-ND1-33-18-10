using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Player.Exceptions
{
    [Serializable]
    public class FileNotPlayableException: PlayerException
    {
        public string Path { get; set; }

        public FileNotPlayableException()
        {
        }

        public FileNotPlayableException(string message) : base(message)
        {
        }

        public FileNotPlayableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileNotPlayableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
