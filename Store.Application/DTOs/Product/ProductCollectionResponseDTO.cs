using Store.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs.Product
{
    public class ProductCollectionResponseDTO : CommonResponse
    {
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
