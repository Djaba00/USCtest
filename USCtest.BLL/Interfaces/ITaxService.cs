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
        Task CreateTaxAsync(FlatModel flatModel);
        Task UpdateTaxAsync(int taxId);
        Task TaxPaymentAsync(int taxId);
    }
}
