using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Exceptions
{
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
    }
}
