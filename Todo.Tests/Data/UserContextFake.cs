using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.API.Repositories;

namespace Todo.Tests.Data
{
    public class UserContextFake : IUserContext
    {
        public int GetCurrentUserId()
        {
            return 1;
        }
    }
}
