using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
            ToTable("Urunler");
            Property(x => x.ProductName).HasColumnName("Urun Ismi");
            Property(x => x.UnitPrice).HasColumnName("Birim Fiyat").HasColumnType("money");
        }
    }
}
