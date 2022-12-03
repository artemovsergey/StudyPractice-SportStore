using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class RelatedProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RelatedProdutId { get; set; }
    }
}
