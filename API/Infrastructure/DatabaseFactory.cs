using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Infrastructure
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
