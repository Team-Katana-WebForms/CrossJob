namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public int AddNew(Comment comment, string userId, string authorId)
        {
            comment.CreatedOn = DateTime.UtcNow;
            comment.RecipientId = userId;
            comment.AuthorId = authorId;

            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment.Id;
        }

        public IQueryable<Comment> GetAllByAuthor(string userId, int skip, int take)
        {
            return this.SortAndPageComments(c => c.AuthorId == userId, skip, take);
        }

        public IQueryable<Comment> GetAllByUser(string userId, int skip, int take)
        {
            return this.SortAndPageComments(c => c.RecipientId == userId, skip, take);
        }

        public IQueryable<Comment> GetById(int id)
        {
            return this.comments
                .All()
                .Where(r => r.Id == id);
        }

        private IQueryable<Comment> SortAndPageComments(Expression<Func<Comment, bool>> filterExpression,int skip,int take)
        {
            return this.comments
                .All()
                .Where(filterExpression)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip)
                .Take(take);
        }
    }
}
