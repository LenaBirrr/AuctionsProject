﻿using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.DataRepositories
{
    public interface ITypeRepository : IRepository<Business.Entities.Type, int> { }
}