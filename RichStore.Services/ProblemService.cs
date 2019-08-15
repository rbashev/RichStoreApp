using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RichStore.Data;
using RichStore.Data.Models;
using RichStore.Services.Models;

namespace RichStore.Services
{
    public class ProblemService : IProblemService
    {
        private readonly RichStoreDbContext dbContext;

        public ProblemService(RichStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<bool> Create(ProblemServiceModel problemServiceModel)
        {
            var customerFromDb = await this.dbContext.Users.SingleOrDefaultAsync(x => x.Id == problemServiceModel.CustomerId);

            if (customerFromDb == null)
            {
                throw new ArgumentNullException(nameof(customerFromDb));
            }

            Problem problem = new Problem
            {
                Description = problemServiceModel.Description,
                Date = problemServiceModel.Date,
                NeedTechnician = problemServiceModel.NeedTechnician
            };

            problem.Customer = (RichStoreUser)customerFromDb;

            await this.dbContext.Problems.AddAsync(problem);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var problemFromDb = this.dbContext.Problems.SingleOrDefaultAsync(x => x.Id == id);

            if (problemFromDb == null)
            {
                throw new ArgumentNullException(nameof(problemFromDb));
            }

            this.dbContext.Remove(problemFromDb);
            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, ProblemServiceModel problemServiceModel)
        {
            var problemFromDb = await this.dbContext.Problems.SingleOrDefaultAsync(x => x.Id == id);
            if (problemFromDb == null)
            {
                throw new ArgumentNullException(nameof(problemFromDb));
            }

            problemFromDb.NeedTechnician = problemServiceModel.NeedTechnician;
            problemFromDb.Description = problemServiceModel.Description;

            this.dbContext.Update(problemFromDb);
            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<Problem> GetAllProblems()
        {
            return this.dbContext.Problems;
        }

        public async Task<ProblemServiceModel> GetProblemById(string id)
        {
            var problemFromDb = await this.dbContext.Problems.SingleOrDefaultAsync(x => x.Id == id);

            if (problemFromDb == null)
            {
                throw new ArgumentNullException(nameof(problemFromDb));
            }

            ProblemServiceModel problem = new ProblemServiceModel
            {
                Date = problemFromDb.Date,
                Description = problemFromDb.Description,
                NeedTechnician = problemFromDb.NeedTechnician,
                CustomerId = problemFromDb.CustomerId
            };

            return problem;
        }
    }
}
