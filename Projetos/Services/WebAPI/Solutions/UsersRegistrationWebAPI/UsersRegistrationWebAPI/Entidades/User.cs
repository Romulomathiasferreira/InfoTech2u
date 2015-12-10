using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public DateTime RegistrationDateUser { get; set; }
        public int RegistrationUserUser { get; set; }
        public DateTime ChangeDateUser { get; set; }
        public int ChangeUserUser { get; set; }
        public string StatusUser { get; set; }
    }
}
