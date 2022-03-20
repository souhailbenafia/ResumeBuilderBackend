using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface ISkillRepository : IGenericRepository<Skill>
    {
        Task<IReadOnlyList<Skill>> GetAllSkillsByUser(string userId);
    }
}
