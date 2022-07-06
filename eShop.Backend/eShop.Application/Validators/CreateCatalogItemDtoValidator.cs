namespace eShop.Application.Validators
{
    public class CreateCatalogItemDtoValidator : AbstractValidator<CreateCatalogItemDto>
    {
        public CreateCatalogItemDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEqual(string.Empty)
                .NotNull();
            RuleFor(c => c.Description)
                .NotEqual(string.Empty)
                .NotNull();
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .NotNull();
            RuleFor(c => c.Price)
                .GreaterThan(0)
                .NotNull();
            RuleFor(c => c.CatalogBrandId)
                .NotEqual(Guid.Empty)
                .NotNull();
            RuleFor(c => c.CatalogTypeId)
                .NotEqual(Guid.Empty)
                .NotNull();
        }
    }
}
