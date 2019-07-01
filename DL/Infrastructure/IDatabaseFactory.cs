using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        dbRevLogContext Get();
    }
}
