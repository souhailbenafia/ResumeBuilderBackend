using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<IReadOnlyList<Project>> GetAllProjectByUser(string userId);
    }
}
