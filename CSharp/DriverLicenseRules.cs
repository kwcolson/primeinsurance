using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    // interface for all of the rules to implement
    public interface IValidateLicense
    {
         bool? Validate(string str, string state);
    }

    // mississippi
    public class ValidateMS: IValidateLicense
    {
        public bool? Validate(string str, string state)
        {
            if (string.IsNullOrEmpty(state)||state !="MS")
                return null;
            return str.NineNumeric();
        }
    }
    //nebraska
    public class ValidateNE : IValidateLicense
    {
        public bool? Validate(string str, string state)
        {
            if (string.IsNullOrEmpty(state) || state != "NE")
                return null;
            if (str.OneAlphaSixNumeric())
                return true;
            if (str.OneAlphaSevenNumeric())
                return true;
            if (str.OneAlphaEightNumeric())
                return true;
            return false;
        }
    }

   
    // interface for the rules service, not specifically needed
    
    public interface IDriverLicenseRules
    {
        bool Validate(string str, string state);
    }
    public class DriverLicenseRules: IDriverLicenseRules
    {
        // collection of our rules to run
        List<IValidateLicense> _rules;
        public DriverLicenseRules()
        {
            // populate the rules
            _rules = CreateRules();
        }

        // here we actually run all of the rules
        public bool Validate(string str, string state)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(str, state);
                // as long as this has not evaluated to null,
                // then a check has been performed and we will
                // return that value, otherwise we will continue to run
                // the tests
                if (result.HasValue)
                    return result.Value;
            }
            return false;
        }

        // a little bit of reflection in order to be able to add the rules up top
        // and have them be run automatically, without having to worry about adding
        // them to the list of rules to run.  A good example of open/close principle for the class
        // DriverLicenseRules, we don't have to change this class in order to extend it
        // to all of the states
        public List<IValidateLicense> CreateRules()
        {
            var myRules = new List<IValidateLicense>();

            // here we are just adding all of the rules that implement the interface
            foreach (Type t in Assembly.GetCallingAssembly().GetTypes())
            {
                if (t.GetInterface("IValidateLicense") != null)
                {
                    IValidateLicense myRule = Activator.CreateInstance(t) as IValidateLicense;
                    myRules.Add(myRule);
                }
            }
            return myRules;
        }


    }
}
