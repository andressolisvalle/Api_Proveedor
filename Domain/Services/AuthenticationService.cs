using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class AuthenticationService
    {
        private readonly IGenericRepository<User> _repository;

        public AuthenticationService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> ValidateUserCredentials(Expression<Func<User, bool>> filter)
        {
            var user = (await _repository.FindAsync(filter)).FirstOrDefault();
            if (user == null)
            {
                throw new IncorrectCredentialsException();
            }


            return user;
        }
    }
}
