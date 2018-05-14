using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLibrary
{
    public class Transaction
    {
        public DateTime TransactionDataTime { get; set; }
        public int CarId { get; set; }
        public int MoneyPaid { get; set; }
    }
}
