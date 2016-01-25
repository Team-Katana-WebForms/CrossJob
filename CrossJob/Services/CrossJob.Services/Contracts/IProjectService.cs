namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;
    using System;

    public interface IProjectService
    {
        IQueryable<Project> GetAll(int skip, int take);

        IQueryable<Project> GetById(int id);

        IQueryable<Project> Update(Project project);

        int AddNew(string title,
            string description,
            int category,
            decimal price,
            string employerId,
            DateTime startDate,
            DateTime endDate);

        void DeleteProject(int id);
    }
}