using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLibrary
{
    public enum CarType
    {
        Passenger,
        Truck,
        Bus,
        Motorcycle
    }
    public enum ErrorCodes
    {
        EmptyList,
        MinusBalance,
        Success,
        NoCar,
        FullParking,
        ParkingHasCarWthThisID,
        Error
    }
}
