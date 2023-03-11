using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            //new ProductValidator-> validator ; Product--> object; product -> entity
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator(); IValidator ile gerek kalmadı
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
