using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class ProfilePicture
    {
        [Key]
        public int IdProfilePicture { get; set; }
        public string PhotoProfilePicture { get; set; }
        public DateTime RegistrationDateProfilePicture { get; set; }
        public int RegistrationUserProfilePicture { get; set; }
        public DateTime ChangeDateProfilePicture { get; set; }
        public int ChangeUserProfilePicture { get; set; }
        public string StatusProfilePicture { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
