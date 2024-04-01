using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IJwtServices
    {
        Task<string> GenerateToken(User user);
    }
}
