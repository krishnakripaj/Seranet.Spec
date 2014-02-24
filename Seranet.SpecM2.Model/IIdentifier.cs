using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.Spec.Models
{
    public interface IIdentifier
    {
        int Id { get; set; }

        Guid GUID { get; set; }

        byte[] RowVersion { get; set; }
    }
}
