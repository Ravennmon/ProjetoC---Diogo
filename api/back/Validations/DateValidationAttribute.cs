namespace back.Validations;
using System;
using System.ComponentModel.DataAnnotations;

public class DateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return false;
        }

        DateTime date;
        if (DateTime.TryParse(Convert.ToString(value), out date))
        {
            return date <= DateTime.Today; 
        }
        return false;
    }
}