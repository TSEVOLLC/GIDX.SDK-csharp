using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;

namespace GIDX.SDK
{
    public interface IGIDXClient
    {
        CustomerRegistrationResponse CustomerRegistration(CustomerRegistrationRequest request);
        CustomerProfileResponse CustomerProfile(string merchantCustomerID, string merchantSessionID);
        CustomerProfileResponse CustomerProfile(CustomerProfileRequest request);
    }
}
