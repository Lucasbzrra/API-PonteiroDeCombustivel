using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class  User :IdentityUser
{

    private static int nextIdUser = 1;
    public int IdUser { get; set; }
    public User() : base() 
    {

        IdUser = nextIdUser;
        nextIdUser++;
    }
  
    public  ICollection<Vehicle> ? vehicles { get; set; }
}
