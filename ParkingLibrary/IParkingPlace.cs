using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    public interface IParkingPlace
    {
        Task<int> AddCar(Car car);
        Task<int> RemoveCar(int car_id);
        Task<bool> RefillCarBalance(int car_id, int sum_to_refill);
        void WriteOff(object obj);
        Task<List<Transaction>> GetTransactionsByLastMinute();
        Task<List<Transaction>> GetTransactionsByLastMinute(int id);
        Task<int> GetFreeSpaceOnParking();
        void SaveTransactionToFile(object obj);
        Task<List<string>> GetTransactionsFromFile();
        void StartDay();
        Task<int> GetBusySpaceOnParking();
        Task<int> TotalParkingProfit();
        int ParkingProfitByLastMinute();
        Task<List<Car>> GetCarList();
        Task<Car> GetCar(int id);
        Task<int> GetBalance();
    }
}
