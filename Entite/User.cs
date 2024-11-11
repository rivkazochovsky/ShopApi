using System.ComponentModel.DataAnnotations;

namespace Entite
{
    public class User
    {
        public int UserId { get; set; }

        [EmailAddress]
        public string UserName { get; set; }
        
        [StringLength(20, ErrorMessage = "password can be betwenn 2 till 20 letters", MinimumLength = 2)]
        public string Password { get; set; }
        
        [StringLength(20, ErrorMessage = "password can be betwenn 2 till 20 letters", MinimumLength = 2), ]
        public string FirstName { get; set; }
        
        [StringLength(20, ErrorMessage = "password can be betwenn 2 till 20 letters", MinimumLength = 2)]
        public string LastName { get; set; }
        

    }
}
