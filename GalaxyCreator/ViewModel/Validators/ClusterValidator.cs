using FluentValidation;

namespace GalaxyCreator.ViewModel.Validators
{
    public class ClusterValidator : AbstractValidator<SectorEditViewModel>
    {
        public ClusterValidator()
        {
            RuleFor(cluster => cluster.Name)
                .NotEmpty()
                .WithMessage("Please specify a Name.");
            RuleFor(cluster => cluster.Description)
               .NotEmpty()
               .WithMessage("Please specify a Description.");
            RuleFor(cluster => cluster.Music)
               .NotEmpty()
               .WithMessage("Please specify a Music.");
            RuleFor(cluster => cluster.Sunlight)
               .NotEmpty()
               .WithMessage("Please specify a Sunlight.");
            RuleFor(cluster => cluster.Economy)
               .NotEmpty()
               .WithMessage("Please specify a Economy.");
            RuleFor(cluster => cluster.Security)
               .NotEmpty()
               .WithMessage("Please specify a Security.");
            RuleFor(cluster => cluster.Backdrop)
               .NotEmpty()
               .WithMessage("Please specify a Backdrop.");
            RuleFor(cluster => cluster.Credits)
                .GreaterThan(0)
                .WithMessage("Please enter a value > 0")
                .When(cluster => cluster.GameStart);
        }
    }
}
