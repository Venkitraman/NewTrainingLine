using Microsoft.AspNetCore.Mvc;
using TrainingLine.Models;

namespace TrainingLine.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public readonly BookDbContext _Context;
        public LoginRepository()
        {
            _Context = new BookDbContext();
        }

        public bool Validate(string username, string password)
        {
            if (username != null && password != null)
            {
                var user = _Context.Users.FirstOrDefault(x => x.Username == username);
                if (user != null)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
    }
}
