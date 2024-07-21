namespace SIGA.Domain.Entities.Relations;
public class UserClaim
{
    public int ApplicationUserId { get; set; }
    public int ClaimId { get; set; }



    public ApplicationUser ApplicationUser { get; set; } = new();
    public Claim Claim { get; set; } = new();
}
