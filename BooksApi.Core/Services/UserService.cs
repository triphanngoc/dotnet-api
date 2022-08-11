using BooksApi.Core.Models;
using BooksApi.Core.Models.User;
using BooksApi.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UsersApi.Core.Services
{
    public class UserService : IUserService
    {
        public readonly IMongoCollection<User> _users;

        private readonly string key;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            //_books = database.GetCollection<Book>(settings.BooksCollectionName);
        }
            public List<User> GetUsers()
                => _users.Find(user => true).ToList();

            public User GetUser(string id)
                => _users.Find<User>(user => user.Id.ToString() == id)
                .FirstOrDefault();

            public User CreateUser(User user)
            {
                _users.InsertOne(user);
                return user;
            }

            public void UpdateUser(string id, User userIn) =>
                _users.ReplaceOne(user => user.Id.ToString() == id, userIn);

            public void RemoveUsers(User userIn) =>
                _users.DeleteOne(user => user.Id.ToString() == userIn.Id.ToString());

            public void RemoveUser(string id) =>
                _users.DeleteOne(user => user.Id.ToString() == id);

            public string Authenticate(string email, string password)
            {
                var user = this._users.Find(x => x.Email == email && x.Password == password).FirstOrDefault();

                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenKey = Encoding.ASCII.GetBytes(key);

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, email),
                    }),

                    Expires = DateTime.UtcNow.AddHours(1),

                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature
                        )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        }
    }