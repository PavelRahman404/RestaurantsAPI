using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;
using System.Collections.Generic;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        private readonly List<string> validCategories = ["Bangladeshi","Chinese","Japanese","korean","Mexican"];
        public CreateRestaurantDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3,100);

            RuleFor(dto => dto.Category)
                .Must(validCategories.Contains)
                .WithMessage("Invalid category. Please choose from the valid categories");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(dto => dto.Category)
                .NotEmpty().WithMessage("Insert a valid category");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress().WithMessage("Please provide a valid email address");

        }
    }
}
