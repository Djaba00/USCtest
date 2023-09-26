using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.BLL.Models;

namespace USCtest.BLL.Interfaces
{
    public interface ITaxService
    {
        Task CreateTax(FlatModel flatModel);
        Task UpdateTax(int taxId);
        Task TaxPayment(int taxId);
    }
}
