﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEventsRepository
    {
        public Task<IEnumerable<Events>> GetAllAsync();
        public Task<Events> GetAsync(int id);
    }
}