﻿namespace CrossJob.Services
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

        public void SaveChanges()
        {
            this.projects.SaveChanges();
        }

        public int AddNew(
            string title,
            string description,
            int category,
            decimal price,
            string employerId,
            DateTime startDate,
            DateTime endDate)
        {
            var newProject = new Project()
            {
                Title = title,
                Description = description,
                CategoryId = category,
                Price = price,
                CreatedOn = DateTime.UtcNow,
                StartOn = startDate,
                FinishOn = endDate,
                EmployerID = employerId
            };

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.ID;
        }

        public void DeleteProject(int id)
        {
            this.projects.Delete(id);
            this.projects.SaveChanges();
        }

        public IQueryable<Project> GetAll()
        {
            return this.projects
             .All()
             .OrderByDescending(r => r.CreatedOn);
        }

        public IQueryable<Project> GetAllProjectsOfUser(string userId, bool isEmployer = false)
        {
            if (isEmployer)
            {
                return this.projects
                 .All()
                 .Where(p => p.EmployerID == userId)
                 .OrderByDescending(r => r.CreatedOn);
            }
            else
            {
                return this.projects
                 .All()
                 .Where(p => p.FreelancerID == userId)
                 .OrderByDescending(r => r.CreatedOn);
            }

        }

        public Project GetById(int id)
        {
            return this.projects
            .All()
            .Where(r => r.ID == id)
            .FirstOrDefault();
        }

        public IQueryable<Project> Update(Project updatedProject)
        {
            this.projects.Update(updatedProject);
            this.projects.SaveChanges();

            return this.projects
                .All()
                .Where(r => r.ID == updatedProject.ID);
        }

        public IQueryable<Project> GetAllLatest(int take)
        {
            return this.projects
                .All()
                .OrderByDescending(p => p.CreatedOn)
                .Take(take);
        }
    }
}
