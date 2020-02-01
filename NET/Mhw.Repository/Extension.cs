using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mhw.Repository
{
    public static class Extension
    {
        public static string GetEntityValidationErrorMessage(this DbEntityValidationException exception)
        {
            var errorMessage = new StringBuilder();

            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                GetValidationErrorMessage(validationErrors, errorMessage);
            }

            return errorMessage.ToString();
        }

        private static void GetValidationErrorMessage(DbEntityValidationResult validationErrors, StringBuilder errorMessage)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
                errorMessage.Append($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")
                    .AppendLine();
            }
        }
    }
}