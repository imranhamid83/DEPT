using DEPT.DAL.Interfaces;
using DEPT.Models;
using DEPT.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEPT.DAL.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        DefaultService service = new DefaultService();

        public async Task<string> ShakeHands()
        {
            return await Task.Run(() => service.ShakeHands());
        }
    }
}
