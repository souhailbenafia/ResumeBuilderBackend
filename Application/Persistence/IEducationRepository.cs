﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IEducationRepository : IGenericRepository<Education>
    {
        Task<IReadOnlyList<Education>> GetAllEducationByUser(string userId);
    }
}
