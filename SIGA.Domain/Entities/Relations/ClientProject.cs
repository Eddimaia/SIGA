using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities.Relations;
public class ClientProject : Entity
{
    public int ClientId { get; set; }
    public int ProjectId { get; set; }


    public Client Client { get; set; } = new Client();
    public Project Project { get; set; } = new Project();
}
