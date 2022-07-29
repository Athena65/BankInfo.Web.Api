using System;

namespace BankInfo.Web.Api.Models
{
    public class BankInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
}
