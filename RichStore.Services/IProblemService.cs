using RichStore.Data.Models;
using RichStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichStore.Services
{
    public interface IProblemService
    {
        IQueryable<Problem> GetAllProblems();

        Task<ProblemServiceModel> GetProblemById(string id);

        Task<bool> Create(ProblemServiceModel problemServiceModel);

        Task<bool> Edit(string id, ProblemServiceModel problemServiceModel);

        Task<bool> Delete(string id);
    }
}
