namespace CrossJob.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IProjectsService
    {
        IQueryable<Project> GetAll(int skip, int take);

        IQueryable<Project> GetById(int id);

        IQueryable<Project> Update(Project project);

        int AddNew(Project newProject, string freelancerId, string employerId);

        void DeleteProject(int id);
    }
}