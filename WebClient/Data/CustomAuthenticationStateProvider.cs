using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;


using Microsoft.JSInterop;
using Models;


using WebClient.Models;


namespace WebClient.Data {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
        private readonly IJSRuntime jsRuntime;
        private readonly IAccountService service;
        private Customer cachedCustomer;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IAccountService restClient) {
            this.jsRuntime = jsRuntime;
            this.service = service;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            var identity = new ClaimsIdentity();
            if (cachedCustomer == null) {
                string customerAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentCustomer");
                if (!string.IsNullOrEmpty(customerAsJson)) {
                    Customer tmp = JsonSerializer.Deserialize<Customer>(customerAsJson);
                    ValidateLogin(tmp.Email, tmp.Password);
                }
            } else {
                identity = SetupClaimsForCustomer(cachedCustomer);
            }
            
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string email, string password) {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Please specify an email");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Please specify a password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try {
                Customer customer = await service.GetAsync<Customer>(email, password);
                identity = SetupClaimsForCustomer(customer);
                string serializedData = JsonSerializer.Serialize(customer);
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentCustomer", serializedData);
                cachedCustomer = customer;
            }
            catch (Exception e) {
                throw e;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

     
        public async Task ValidateRegister(string firstName,string lastName,string email, string password, string confirmationPassword) {
            if (string.IsNullOrWhiteSpace(firstName)) throw new Exception("Please specify a first name");
            if (string.IsNullOrWhiteSpace(lastName)) throw new Exception("Please specify a last name");
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Please specify an email");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Please specify a password");
            if (string.IsNullOrWhiteSpace(confirmationPassword)) throw new Exception("Please confirm your password");
            
            if (!password.Equals(confirmationPassword))
                throw new Exception("Passwords do not match");

            Customer customer = new Customer() {
                Email = email,
                Password = password,
               Role = Role.Customer
            }; 

            await service.PostAsync(customer);
        }

        public void Logout() {
            cachedCustomer = null;
            var customer = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentCustomer", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(customer)));
        }

        private void NotifyAuthenticationStateChanged(Task<AuthenticationState> fromResult)
        {
            throw new NotImplementedException();
        }

        private ClaimsIdentity SetupClaimsForCustomer(Customer customer) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, customer.Role.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }

    public class AuthenticationStateProvider
    {
        public virtual Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class AuthenticationState
    {
        public AuthenticationState(ClaimsPrincipal cachedClaimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public object Customer { get; }
    }
}