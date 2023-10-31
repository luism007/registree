public class User  {
    public int Id {get; set;}
    public required string Email {get; set;}
    public required string Password {get; set;}
    public required string SecurityAnswer1 {get; set;}
    public required string SecurityAnswer2 {get; set;}
    public string? UserType {get; set;}

}