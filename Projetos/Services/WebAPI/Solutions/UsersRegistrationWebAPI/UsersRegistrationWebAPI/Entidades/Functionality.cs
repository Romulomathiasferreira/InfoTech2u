using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class Functionality
    {
        [Key]
        public int IdFunctionality { get; set; }
        public string NameFunctionality { get; set; }
        public string DescriptionFunctionality { get; set; }
        public DateTime RegistrationDateFunctionality { get; set; }
        public int RegistrationUserFunctionality { get; set; }
        public DateTime ChangeDateFunctionality { get; set; }
        public int ChangeUserFunctionality { get; set; }
        public string StatusFunctionality { get; set; }
        public int ApplicationModuleId { get; set; }
        public virtual ApplicationModule ApplicationModule { get; set; }
    }
}
