using System;
using System.ComponentModel.DataAnnotations;

namespace IOTLabWebApi.Controllers.Resources
{
    public class UserAppProfileResource
    {
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage ="Debe ser un email valido")]
        public string Email { get; set; }
    }
}