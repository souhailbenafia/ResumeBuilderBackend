﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface ILanguageRepository : IGenericRepository<Language>
    {
        Task<IReadOnlyList<Language>> GetAllLanguageByUser(string userId);
    }
}
