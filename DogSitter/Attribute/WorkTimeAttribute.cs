using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DogSitter.API.Attribute
{
    public class TimeFormat : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex regex = new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            string workTimeValue = value as string;
            if (!regex.IsMatch(workTimeValue))
            {
                return false;
            }
            return true;
        }
    }
}
