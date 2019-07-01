using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        dbRevLogContext Get();
    }
}
