namespace BB103_Pronia.ViewModels;

public class LoginVm
{
    [Required]
    public string UsernameOrEmail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
