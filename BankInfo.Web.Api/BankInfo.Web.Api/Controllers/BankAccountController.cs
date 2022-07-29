using BankInfo.Web.Api.Models;
using BankInfo.Web.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankInfo.Web.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : Controller
    {
        private readonly IBankService _bankService;
     
        public BankAccountController(IBankService bankService)
        {
            _bankService = bankService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBankInfo()
        {
           return Ok(await _bankService.GetAllBankInfo());
        }
        [HttpPost]
        public async Task<IActionResult> CreateBankInfo(Models.BankInfo bankinfo) 
        {
           
            return Ok(await _bankService.CreateBankInfo(bankinfo));

           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankInfo(int id)
        {
            return Ok(await _bankService.DeleteBankInfo(id));  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBankInfo(Models.BankInfo bankId)
        {
            return Ok(await _bankService.UpdateBankInfo(bankId));
        }






    }
}
