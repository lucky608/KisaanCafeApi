using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Models
{
    public class PutActionResult
    {
       
            /// <summary>
            /// Specifies the relative url the new resource if the operation adds a new resource in case resource which needs to be updated is not found
            /// Either NewResourceLocationRouteInfo or NewResourcePath need to be set
            /// This is an optional attribute
            /// </summary>
            public string NewResourceRelativeUrl { get; set; }

            /// <summary>
            /// Specifies the result code of the put operation
            /// </summary>
            public PutActionResultCode Result { get; set; }

            /// <summary>
            /// Object which represents the new resource
            /// This is an optional attribute
            /// </summary>
            public object NewResourceValue { get; set; }
     
    }

}

