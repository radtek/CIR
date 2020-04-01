using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cir.WebApp.Offline.Models.Cir.Users
{
    /// <summary>
    /// User model
    /// </summary>
    public class UserModel
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Please enter full initials")]
        public string Initials { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter user name")]
        public string Username { get; set; }

        public string Role { get; set; }

        [Display(Name = "Permission")]
        public int RoleID { get; set; }

        public List<Roles> Roles { get; set; }

        public bool IsSuccess { get; set; }

    }

    /// <summary>
    /// Role class
    /// </summary>
    public class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}