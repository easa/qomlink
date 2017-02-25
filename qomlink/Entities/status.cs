using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public enum status
    {
		  Connected,
		  Disconnected,
		  Already_connected,
		  Already_disconnected,
		  Registered,
		  Already_registered,
		  Bad_getway,
		  Not_found,
		  Not_authorized,
        Ok,
		  Error
    }
}
