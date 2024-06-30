namespace back.Validations;

using System;
using System.ComponentModel.DataAnnotations;

public class MaiorDeIdadeAttribute : ValidationAttribute
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
            return date <= DateTime.Today.AddYears(-18);
        }
        return false;
    }
}