namespace eShop.Application.Validators
{
    public class CatalogBrandDtoValidator : AbstractValidator<CatalogBrandDto>
    {
        public CatalogBrandDtoValidator()
        {
            RuleFor(x => x.BrandName)
                .NotEqual(string.Empty)
                .NotNull();
        }
    }
}
