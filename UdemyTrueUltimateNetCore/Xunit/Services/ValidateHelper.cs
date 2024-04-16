using System.ComponentModel.DataAnnotations;

namespace CRUDExample
{
    public static class ValidateHelper<T>
    {
        public static bool Validate(T? obj)
        {
            if (obj is null) throw new ArgumentNullException();
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, results, true);
            if (!isValid)
            {
                throw new ArgumentException();
            }
            return true;
        }
    }
}
