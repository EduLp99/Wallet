using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletProject.Application.InputModels
{
    public class CreateWalletInputModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Bank { get; set; }
        public decimal Value { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
