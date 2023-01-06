using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Comments
{
	/// <summary>
	/// Service to access the comments
	/// </summary>
	public interface ICommentService
	{
		/// <summary>
		/// Gets the comments availables.
		/// </summary>
		/// <returns>A List of comment if the client is connected to the Internet</returns>
		public Task<List<Comment>> GetCommentAsync();

		///// <summary>
		///// Add the comment.
		///// </summary>
		///// <returns>Nothing</returns>
		///// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
		//public Task<Comment> AddCommentAsync(Comment comment);

	}
}