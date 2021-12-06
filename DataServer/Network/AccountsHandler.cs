using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class AccountsHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;
        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public AccountsHandler()
        {
            unitOfWork = new UnitOfWork(new RestaurantDbContext());

            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            options.Converters.Add(new DateTimeConverter());

            optionsWithoutConverter = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<string> ProcessClientRequestType(string requestType, string args)
        {
            switch (requestType)
            {
                case "createEmployeeAccount":
                    return await CreateEmployeeAccount(args);
                case "createCustomerAccount":
                    return await CreateCustomerAccount(args);
                case "getEmployeeAccount":
                    return await GetEmployeeAccount(args);
                case "getCustomerAccount":
                    return await GetCustomerAccount(args);
                default:
                    return "";
            }
        }

        private async Task<string> GetCustomerAccount(string args)
        {
            return JsonSerializer.Serialize(await unitOfWork.AccountsRepository.GetCustomerAccountAsync(args), optionsWithoutConverter);
        }

        private async Task<string> GetEmployeeAccount(string args)
        {
            return JsonSerializer.Serialize(await unitOfWork.AccountsRepository.GetEmployeeAccountAsync(args), optionsWithoutConverter);
        }

        private async Task<string> CreateEmployeeAccount(string args)
        {
            Employee employee = JsonSerializer.Deserialize<Employee>(args, options);
            await unitOfWork.AccountsRepository.CreateAccountAsync(employee);
            await unitOfWork.Save();
            return JsonSerializer.Serialize(employee, optionsWithoutConverter);
        }
        private async Task<string> CreateCustomerAccount(string args)
        {
            Customer customer = JsonSerializer.Deserialize<Customer>(args, options);
            await unitOfWork.AccountsRepository.CreateAccountAsync(customer);
            await unitOfWork.Save();
            return JsonSerializer.Serialize(customer, optionsWithoutConverter);
        }
        
        
    }
}