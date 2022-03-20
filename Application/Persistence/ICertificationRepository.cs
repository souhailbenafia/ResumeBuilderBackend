using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Persistence
{
    public interface ICertificationRepository : IGenericRepository<Certification> 
    {
        Task<IReadOnlyList<Certification>> GetAllCertificationByUser (string userId);
    }
}
