﻿namespace CrossJob.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetById(int id);

        IQueryable<Comment> GetAllByUser(string userId, int skip, int take);

        List<Comment> GetAllByAuthor(string userId, int skip, int take);

        int AddNew(string comment, string userId, string authorId);
    }
}