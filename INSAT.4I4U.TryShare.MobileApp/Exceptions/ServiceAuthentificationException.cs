using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Exceptions
{
    [Serializable]
    public class ServiceAuthentificationException : Exception
    {
        public string Content { get; }

        public ServiceAuthentificationException() : base()
        {
        }

        public ServiceAuthentificationException(string content) : base(content)
        {   
            Content = content;
        }

        protected ServiceAuthentificationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ServiceAuthentificationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
