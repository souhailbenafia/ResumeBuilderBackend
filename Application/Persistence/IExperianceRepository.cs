using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IExperianceRepository : IGenericRepository<Experience>
    {
        Task<IReadOnlyList<Experience>> GetAllExperienceByUser(string userId);
    }
}
