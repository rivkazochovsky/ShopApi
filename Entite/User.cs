using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entite;

public partial class User
{
    public int UserId { get; set; }
    [EmailAddress]
    public string UserName { get; set; } = null!;

    [StringLength(20, ErrorMessage = "password can be betwenn 2 till 20 letters", MinimumLength = 2)]

    public string Password { get; set; } = null!;

    [StringLength(20, ErrorMessage = "firstName can be betwenn 2 till 20 letters", MinimumLength = 2),]


    public string FirstName { get; set; } = null!;

    [StringLength(20, ErrorMessage = "LastName can be betwenn 2 till 20 letters", MinimumLength = 2)]

    public string LastName { get; set; } = null!;
}
