using SIGA.Domain.Entities.Common;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Domain.Entities;
public class ApplicationUser : Entity
{
    public ApplicationUser() { }
    public ApplicationUser(
        int id,
        string firstName,
        string lastName,
        string login,
        string userName,
        string password,
        string email,
        string? phoneNumber,
        DateTime birthDate,
        DateTime lastLoginDate,
        DateTime createdAt,
        bool isEmailConfirmed,
        bool isPhoneNumberConfirmed,
        bool isEmployed,
        bool isProjectCoordinator)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Login = login;
        UserName = userName;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        LastLoginDate = lastLoginDate;
        CreatedAt = createdAt;
        IsEmailConfirmed = isEmailConfirmed;
        IsPhoneNumberConfirmed = isPhoneNumberConfirmed;
        IsEmployed = isEmployed;
        IsProjectCoordinator = isProjectCoordinator;
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneNumberConfirmed { get; set; }
    public bool IsEmployed { get; set; }
    public bool IsProjectCoordinator { get; set; }



    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<Project> CoordinatorProjects { get; set; } = new List<Project>();
    public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    public ICollection<VpnAccess> VpnAccesses { get; set; } = new List<VpnAccess>();
    public ICollection<CoordinatorProject> CoordinatorsProjects { get; set; } = new List<CoordinatorProject>();
    public ICollection<ApplicationUserClaim> UserClaims { get; set; } = new List<ApplicationUserClaim>();
    public ICollection<ApplicationUserProject> UserProjects { get; set; } = new List<ApplicationUserProject>();
    public ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}
