using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersRegistrationWebAPI.Entidades;

namespace UsersRegistrationWebAPI.dao
{
    public class UserDAO
    {
        private EntidadesContext context;

        public UserDAO(EntidadesContext context)
        {
            this.context = context;
        }

        public void Adiciona(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public IList<User> Lista()
        {
            return context.Users.ToList();
        }
    }
}
