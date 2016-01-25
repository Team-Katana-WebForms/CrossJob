namespace CrossJob.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<Project> projects;

        public ProjectsService(IRepository<Project> projects)
        {
            this.projects = projects;
        }

        public int AddNew(Project newProject, string freelancerId, string employerId)
        {
            newProject.CreatedOn = DateTime.UtcNow;
            newProject.FreelancerID = freelancerId;
            newProject.EmployerID = employerId;

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.ID;
        }

        public void DeleteProject(int id)
        {
            this.projects.Delete(id);
            this.projects.SaveChanges();
        }

        public IQueryable<Project> GetAll(int skip, int take)
        {
            return this.projects
             .All()
             .OrderByDescending(r => r.CreatedOn)
             .Skip(skip)
             .Take(take);
        }

        public IQueryable<Project> GetById(int id)
        {
            return this.projects
            .All()
            .Where(r => r.ID == id);
        }

        public IQueryable<Project> Update(Project updatedProject)
        {
            this.projects.Update(updatedProject);
            this.projects.SaveChanges();

            return this.projects
                .All()
                .Where(r => r.ID == updatedProject.ID);
        }
    }
}
