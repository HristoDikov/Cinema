namespace Cinema.Server.Infrastructure.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date >= DateTime.Now; //Dates Greater than or equal to today are valid (true)
        }
    }
}
