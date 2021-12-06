using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;
using WebClient.Models;

namespace WebClient.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IAccountService accountService;
        private Person cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IAccountService accountService)
        {
            this.jsRuntime = jsRuntime;
            this.accountService = accountService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    var tmp = JsonSerializer.Deserialize<Person>(userAsJson);
                    await ValidateLogin(tmp.Email, tmp.Password);
                }
            }
            else
            {
                if (cachedUser.GetType() == typeof(Customer))
                {
                    identity = SetupClaimsForCustomer((Customer) cachedUser);
                }
                else
                {
                    identity = SetupClaimsForEmployee((Employee) cachedUser);
                }
                
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Please specify an email");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Please specify a password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                if (email.Trim().EndsWith("@restaurant.dk"))
                {
                    Employee employee = await accountService.GetEmployeeAccountAsync(email, password);
                    if (employee == null) throw new Exception("User not found");
                    identity = SetupClaimsForEmployee(employee);
                    string serializedData = JsonSerializer.Serialize(employee);
                    await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);
                    cachedUser = employee;
                }
                else
                {
                    Customer customer = await accountService.GetCustomerAccountAsync(email, password);
                    if (customer == null) throw new Exception("User not found");
                    identity = SetupClaimsForCustomer(customer);
                    string serializedData = JsonSerializer.Serialize(customer);
                    await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);
                    cachedUser = customer;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }


        public async Task ValidateRegister(string firstName, string lastName, string email, string password,
            string confirmationPassword)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new Exception("Please specify a first name");
            if (string.IsNullOrWhiteSpace(lastName)) throw new Exception("Please specify a last name");
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Please specify an email");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Please specify a password");
            if (string.IsNullOrWhiteSpace(confirmationPassword)) throw new Exception("Please confirm your password");

            if (!password.Equals(confirmationPassword))
                throw new Exception("Passwords do not match");

            if (email.Trim().EndsWith("@restaurant.dk"))
            {
                Employee user = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password
                };

                await accountService.CreateEmployeeAsync(user);
            }
            else
            {
                Customer user = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password
                };

                await accountService.CreateCustomerAsync(user);
            }
        }

        public void Logout()
        {
            cachedUser = null;
            var customer = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentCustomer", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(customer)));
        }

        private ClaimsIdentity SetupClaimsForCustomer(Customer user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Role, Role.Customer.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }

        private ClaimsIdentity SetupClaimsForEmployee(Employee user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Role, Role.Employee.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}