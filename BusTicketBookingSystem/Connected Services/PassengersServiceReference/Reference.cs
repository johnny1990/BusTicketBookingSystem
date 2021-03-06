﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusTicketBookingSystem.PassengersServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PassengersServiceReference.IPassengersService")]
    public interface IPassengersService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/GetAllPassengers", ReplyAction="http://tempuri.org/IPassengersService/GetAllPassengersResponse")]
        BusTicketBookingSystem.Entities.Models.Passenger[] GetAllPassengers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/GetAllPassengers", ReplyAction="http://tempuri.org/IPassengersService/GetAllPassengersResponse")]
        System.Threading.Tasks.Task<BusTicketBookingSystem.Entities.Models.Passenger[]> GetAllPassengersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/GetPassengerById", ReplyAction="http://tempuri.org/IPassengersService/GetPassengerByIdResponse")]
        BusTicketBookingSystem.Entities.Models.Passenger GetPassengerById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/GetPassengerById", ReplyAction="http://tempuri.org/IPassengersService/GetPassengerByIdResponse")]
        System.Threading.Tasks.Task<BusTicketBookingSystem.Entities.Models.Passenger> GetPassengerByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/AddPassenger", ReplyAction="http://tempuri.org/IPassengersService/AddPassengerResponse")]
        int AddPassenger(string Name, bool Blocked);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/AddPassenger", ReplyAction="http://tempuri.org/IPassengersService/AddPassengerResponse")]
        System.Threading.Tasks.Task<int> AddPassengerAsync(string Name, bool Blocked);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/UpdatePassenger", ReplyAction="http://tempuri.org/IPassengersService/UpdatePassengerResponse")]
        int UpdatePassenger(int Id, string Name, bool Blocked);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/UpdatePassenger", ReplyAction="http://tempuri.org/IPassengersService/UpdatePassengerResponse")]
        System.Threading.Tasks.Task<int> UpdatePassengerAsync(int Id, string Name, bool Blocked);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/DeletePassengerById", ReplyAction="http://tempuri.org/IPassengersService/DeletePassengerByIdResponse")]
        int DeletePassengerById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPassengersService/DeletePassengerById", ReplyAction="http://tempuri.org/IPassengersService/DeletePassengerByIdResponse")]
        System.Threading.Tasks.Task<int> DeletePassengerByIdAsync(int Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPassengersServiceChannel : BusTicketBookingSystem.PassengersServiceReference.IPassengersService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PassengersServiceClient : System.ServiceModel.ClientBase<BusTicketBookingSystem.PassengersServiceReference.IPassengersService>, BusTicketBookingSystem.PassengersServiceReference.IPassengersService {
        
        public PassengersServiceClient() {
        }
        
        public PassengersServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PassengersServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PassengersServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PassengersServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BusTicketBookingSystem.Entities.Models.Passenger[] GetAllPassengers() {
            return base.Channel.GetAllPassengers();
        }
        
        public System.Threading.Tasks.Task<BusTicketBookingSystem.Entities.Models.Passenger[]> GetAllPassengersAsync() {
            return base.Channel.GetAllPassengersAsync();
        }
        
        public BusTicketBookingSystem.Entities.Models.Passenger GetPassengerById(int Id) {
            return base.Channel.GetPassengerById(Id);
        }
        
        public System.Threading.Tasks.Task<BusTicketBookingSystem.Entities.Models.Passenger> GetPassengerByIdAsync(int Id) {
            return base.Channel.GetPassengerByIdAsync(Id);
        }
        
        public int AddPassenger(string Name, bool Blocked) {
            return base.Channel.AddPassenger(Name, Blocked);
        }
        
        public System.Threading.Tasks.Task<int> AddPassengerAsync(string Name, bool Blocked) {
            return base.Channel.AddPassengerAsync(Name, Blocked);
        }
        
        public int UpdatePassenger(int Id, string Name, bool Blocked) {
            return base.Channel.UpdatePassenger(Id, Name, Blocked);
        }
        
        public System.Threading.Tasks.Task<int> UpdatePassengerAsync(int Id, string Name, bool Blocked) {
            return base.Channel.UpdatePassengerAsync(Id, Name, Blocked);
        }
        
        public int DeletePassengerById(int Id) {
            return base.Channel.DeletePassengerById(Id);
        }
        
        public System.Threading.Tasks.Task<int> DeletePassengerByIdAsync(int Id) {
            return base.Channel.DeletePassengerByIdAsync(Id);
        }
    }
}
