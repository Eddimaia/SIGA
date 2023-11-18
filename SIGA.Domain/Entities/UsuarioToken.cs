using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Domain.Entities;
public class UsuarioToken
{
	public string Token { get; set; }
	public DateTime Expiration { get; set; }
}
