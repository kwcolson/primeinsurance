using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace CSharp
{
    public static class DriverLicense
    {

       
        /// <summary>
        /// Consider this list of formats: https://ntsi.com/drivers-license-format/
        /// Validate Driver's license number, implement Nebraska and Mississippi in an expandable way to eventually handle all US states.
        /// Fail validation if unpected data is passed in.
        /// Nebraska: 1Alpha+6-8Numeric
        /// Mississippi: 9Numeric
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="stateCode"></param>
        /// <returns></returns>
        public static bool Validate(string licenseNumber, string stateCode)
        {
            IDriverLicenseRules DLRules = new DriverLicenseRules();
            return DLRules.Validate(licenseNumber, stateCode);
            //return false;
        }

       
    }
}
