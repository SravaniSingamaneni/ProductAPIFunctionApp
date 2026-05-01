using ProductAPIFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPIFunctionApp.Repository
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task DeleteAsync(string id);
    }
}
