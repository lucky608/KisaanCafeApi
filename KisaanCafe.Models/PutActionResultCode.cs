using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Models
{
    public enum PutActionResultCode
    {
        ResourceAddedSuccessfully,
        ResourceUpdatedSuccessfully,
        ResourceFailedToUpdate,
        ResourceNotFound
    }
}
