using System.ComponentModel.DataAnnotations;

public class TransportTypeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string inputValue = value.ToString().ToLower();
            if (inputValue != "car" && inputValue != "plane" && inputValue != "bus")
            {
                return new ValidationResult("The input value must be one of the following values: car, plane, bus");
            }
        }
        return ValidationResult.Success;
    }
}
