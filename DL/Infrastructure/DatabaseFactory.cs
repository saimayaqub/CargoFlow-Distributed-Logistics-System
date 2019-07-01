using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private dbRevLogContext dataContext;
        public dbRevLogContext Get()
        {
            return dataContext ?? (dataContext = new dbRevLogContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
