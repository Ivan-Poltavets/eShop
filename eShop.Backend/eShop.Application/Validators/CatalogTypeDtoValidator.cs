namespace eShop.Application.Validators
{
    public class CatalogTypeDtoValidator : AbstractValidator<CatalogTypeDto>
    {
        public CatalogTypeDtoValidator()
        {
            RuleFor(x => x.TypeName)
                .NotEqual(string.Empty)
                .NotNull();
        }
    }
}
