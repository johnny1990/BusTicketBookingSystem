using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusTicketBookingSystem.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDriversService" in both code and config file together.
    [ServiceContract]
    public interface IDriversService
    {
        [OperationContract]
        List<Driver> GetAllDrivers();

        [OperationContract]
        Driver GetDriverById(int DriverId);

        [OperationContract]
        int AddDriver(string Name, string SerialNumber, string DriverLicence, string PhoneNumber, string EmailAddress, bool IsAvailable);
      
        [OperationContract]
        int UpdateDriver(int DriverId, string Name, string SerialNumber, string DriverLicence, string PhoneNumber, string EmailAddress, bool IsAvailable);

        [OperationContract]
        int DeleteDriverById(int DriverId);
    }
}
