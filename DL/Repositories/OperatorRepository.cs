using DL.Infrastructure;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class OperatorRepository : RepositoryBase<Operator>, IOperatorRepository
    {
        public OperatorRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IOperatorRepository : IRepository<Operator>
    {
    }
}
