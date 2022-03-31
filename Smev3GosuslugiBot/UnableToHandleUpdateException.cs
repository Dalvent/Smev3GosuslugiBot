using System;
using System.Runtime.Serialization;

namespace Smev3GosuslugiBot
{
    [Serializable]
    public class UnableToHandleUpdateException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public UnableToHandleUpdateException()
        {
        }

        public UnableToHandleUpdateException(string message) : base(message)
        {
        }

        public UnableToHandleUpdateException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UnableToHandleUpdateException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}