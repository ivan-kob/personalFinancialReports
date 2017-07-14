using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string Exchange { get; set; }
    }
}
