using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BankInfo.Web.Api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Models.BankInfo> BankInfos { get; set; }
    }
}
