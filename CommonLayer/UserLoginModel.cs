using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="{0} should not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Password { get; set; }
    }
}
