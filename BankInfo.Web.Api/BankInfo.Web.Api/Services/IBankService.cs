using BankInfo.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankInfo.Web.Api.Services
{
    public interface IBankService
    {

        Task<ServiceResponse<List<Models.BankInfo>>> CreateBankInfo(Models.BankInfo newBank);
        Task<ServiceResponse<List<Models.BankInfo>>> DeleteBankInfo(int bankId);
        Task<ServiceResponse<List<Models.BankInfo>>> GetAllBankInfo();
        Task<ServiceResponse<List<Models.BankInfo>>> UpdateBankInfo(Models.BankInfo bankId);    
  
    }
}
