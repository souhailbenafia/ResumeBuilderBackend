﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IInterestRepository:  IGenericRepository<Interest>
    {
        Task<IReadOnlyList<Interest>> GetAllInterestByUser(string userId);
    }
}
