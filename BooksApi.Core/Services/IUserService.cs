using BooksApi.Core.Models.User;
using System.Collections.Generic;

namespace BooksApi.Core.Services
{
    public interface IUserService
    {
        /*User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);*/

        List<User> GetUsers();
        User GetUser(string id);
        User CreateUser(User user);
        void UpdateUser(string id, User userIn);
        void RemoveUser(string id);
        void RemoveUsers(User userIn);
        string Authenticate(string email, string password);




    }
}
