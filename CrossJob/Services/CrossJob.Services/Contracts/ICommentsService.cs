namespace CrossJob.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetById(int id);

        List<Comment> GetAllByUser(string userId, int skip, int take);

        IQueryable<Comment> GetAllByAuthor(string userId, int skip, int take);

        int AddNew(Comment comment, string userId, string authorId);
    }
}