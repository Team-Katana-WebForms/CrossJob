namespace CrossJob.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    public interface ICommentService
    {
        IQueryable<Comment> GetById(int id);

        IQueryable<Comment> GetAllByUser(string userId, int skip, int take);

        IQueryable<Comment> GetAllByAuthor(string userId, int skip, int take);

        int AddNew(Comment comment, string userId, string authorId);
    }
}