using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEPT.DAL.Interfaces
{
    public interface IConnectionRepository
    {
       Task<string>  ShakeHands();

    }
}
