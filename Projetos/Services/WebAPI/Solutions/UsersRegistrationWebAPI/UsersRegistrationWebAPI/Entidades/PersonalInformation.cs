using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class PersonalInformation
    {
        [Key]
        public int IdPersonalInformation { get; set; }
        public string NamePersonalInformation { get; set; }
        public string NicknamePersonalInformation { get; set; }
        public DateTime BirthDatePersonalInformation { get; set; }
        public string GenrePersonalInformation { get; set; }
        public DateTime RegistrationDatePersonalInformation { get; set; }
        public int RegistrationUserPersonalInformation { get; set; }
        public DateTime ChangeDatePersonalInformation { get; set; }
        public int ChangeUserPersonalInformation { get; set; }
        public string StatusPersonalInformation { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
