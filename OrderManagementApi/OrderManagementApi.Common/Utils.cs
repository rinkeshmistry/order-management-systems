using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApi.Common
{
    public static class Utils
    {
        public static bool IsNullOrBlank(dynamic value)
        {
            return (value == null || value == "") ? true : false;
        }
    }
}
