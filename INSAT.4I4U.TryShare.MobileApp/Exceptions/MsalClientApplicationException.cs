using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Exceptions
{

	[Serializable]
	public class MsalClientApplicationException : Exception
	{
		public MsalClientApplicationException() { }
		public MsalClientApplicationException(string message) : base(message) { }
		public MsalClientApplicationException(string message, Exception inner) : base(message, inner) { }
		protected MsalClientApplicationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
