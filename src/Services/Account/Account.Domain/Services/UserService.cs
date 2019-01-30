using Account.Domain.Entity;
using Account.Domain.Interfaces.Repository;
using Account.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Account.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User entity)
        {
            return _userRepository.Add(entity);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }

        public void Remove(User entity)
        {
            _userRepository.Remove(entity);
        }

        public IEnumerable<User> All()
        {
            return _userRepository.All();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.Find(predicate);
        }

        public User FindById(int id)
        {
            return _userRepository.FindById(id);
        }
    }
}
