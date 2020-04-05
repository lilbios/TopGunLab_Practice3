using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopGunLab_Practice3.Models.Third_part
{
    public static class IdBangerProduct
    {
        public static int UpdateId(IEnumerable<Product> products)
        {
            var last = products.LastOrDefault();
            return last != null ? last.ProductId + 1 : 1;
        }
    }
}