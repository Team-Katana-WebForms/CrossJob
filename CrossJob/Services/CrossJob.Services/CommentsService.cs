namespace CrossJob.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public int AddNew(Comment comment, string userId, string authorId)
        {
            comment.CreatedOn = DateTime.UtcNow;
            comment.FreelancerId = userId;
            comment.EmployerId = authorId;

            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment.Id;
        }

        public IQueryable<Comment> GetAllByAuthor(string userId, int skip, int take)
        {
            return this.SortAndPageComments(c => c.EmployerId == userId, skip, take);
        }

        public List<Comment> GetAllByUser(string userId, int skip, int take)
        {
            return this.SortAndPageComments(c => c.FreelancerId == userId, skip, take).ToList();
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
