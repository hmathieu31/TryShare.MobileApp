using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Comments
{
    /// <summary>
    /// TODO
    /// This is a mock service for the Comment service.
    /// </summary>
    public class CommentMockService : ICommentService
    {

        private readonly List<Model.Comment> commentList = new();

        public CommentMockService()
        {
            commentList.Add(new Comment { Id = 000001, PostedDate ="10h30, 15/12/2022", Commentaire ="ce velo est en parfait état" });
            commentList.Add(new Comment { Id = 000002, PostedDate = "12h15, 10/12/2022", Commentaire = "ce velo laisse à désirer" });
            commentList.Add(new Comment { Id = 000003, PostedDate = "1h15, 18/12/2022", Commentaire = "monteil le sang" });
        }

        public Task<List<Model.Comment>> GetCommentAsync()
        {
            return Task.FromResult(commentList);
        }

    }
}
