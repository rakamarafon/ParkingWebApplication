using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLibrary
{
    public class Car
    {
        public int CarId { get; set; }
        private int _balance;
        public int Balance
        {
            get
            {
                lock (syncBalance)
                {
                    return _balance;
                }
            }
            set
            {
                lock (syncBalance)
                {
                    _balance = value;
                }
            }
        }
        public CarType Type { get; set; }

        private object syncBalance = new object();
    }
}
