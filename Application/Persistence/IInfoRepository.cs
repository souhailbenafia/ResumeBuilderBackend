using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public  interface IInfoRepository : IGenericRepository<Info>
    {
        Task<IReadOnlyList<Info>> GetAllCertificationByUser(string userId);
    }
}
