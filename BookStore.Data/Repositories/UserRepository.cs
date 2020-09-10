using BookStore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserNameAndPassword(string userName, string passWord);
        //User GetUserByGoogleByIdentity(string googleId);
    }
    public class UserRepository : IUserRepository
    {
        private BookStoreDBContext _context;
        public UserRepository(BookStoreDBContext context)
        {
            _context = context;
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    UserId="test_id",
                    FullName = "test",
                    UserName = "Admin",
                    Role = "Admin",
                    GoogleId = "123",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7"
                });
                _context.SaveChanges();
            }
        }

        //public   User IUserRepository.GetUserByGoogleByIdentity(string googleId)
        //   {
        //       throw new NotImplementedException();
        //   }

        public User GetUserNameAndPassword(string userName, string passWord)
        {
            var hasPass = ComputeSha256Hash(passWord);
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == hasPass);
            return user;
        }
        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
