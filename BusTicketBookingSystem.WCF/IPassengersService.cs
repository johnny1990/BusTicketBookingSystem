using BusTicketBookingSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusTicketBookingSystem.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPassengersService" in both code and config file together.
    [ServiceContract]
    public interface IPassengersService
    {
        [OperationContract]
        List<Passenger> GetAllPassengers();

        [OperationContract]
        Passenger GetPassengerById(int Id);

        [OperationContract]
        int AddPassenger(string Name, bool Blocked);

        [OperationContract]
        int UpdatePassenger(int Id, string Name, bool Blocked);

        [OperationContract]
        int DeletePassengerById(int Id);
    }
}
