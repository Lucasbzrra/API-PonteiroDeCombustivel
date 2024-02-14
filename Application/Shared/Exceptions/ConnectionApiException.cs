using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Exceptions;

public class ConnectionApiException:Exception
{
	public ConnectionApiException(string message):base(message)
	{

	}
}
