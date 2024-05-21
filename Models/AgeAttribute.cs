using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SububanMedicalGroupSMGWebApp.Models
{
    public class AgeAttribute : ValidationAttribute, IClientModelValidator
    {
        private int maxAge;

        public AgeAttribute(int maxAge)
        {
            this.maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext ctx)
        {
            if (value is DateTime)
            {
                DateTime CheckDate = (DateTime)value;
                DateTime minimumDate = DateTime.Today.AddYears(-150);

                if (CheckDate <= DateTime.Today && CheckDate >= minimumDate)
                {
                    return ValidationResult.Success!;
                }
            }

            return new ValidationResult(GetMsg(ctx.DisplayName ?? "Date"));
        }
        private string GetMsg(string name) =>
            base.ErrorMessage ?? $"{name} must be a past date and no more than {maxAge} years ago.";
        public void AddValidation(ClientModelValidationContext ctx)
        {
            if (!ctx.Attributes.ContainsKey("data-val"))
                ctx.Attributes.Add("data-val", "true");

            ctx.Attributes.Add("data-val-DateAge-ageDateMax", maxAge.ToString());
            ctx.Attributes.Add("data-val-MaxageDate",
                GetMsg(ctx.ModelMetadata.DisplayName ?? ctx.ModelMetadata.Name ?? "Date"));
        }

        
    }
}
