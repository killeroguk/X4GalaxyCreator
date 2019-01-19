using FluentValidation;

namespace GalaxyCreator.ViewModel.Validators
{
    /** code example to be found on: https://gist.github.com/holymoo/11243164 */
    public class GalaxyValidator : AbstractValidator<GalaxyEditViewModel>
    {
        public GalaxyValidator()
        {
            RuleFor(galaxy => galaxy.Seed)
                .GreaterThan(0)
                .WithMessage("Please Specify a Seed.");
            RuleFor(galaxy => galaxy.GalaxyName)
                .NotEmpty()
                .WithMessage("Please Specify a Name.");
            RuleFor(galaxy => galaxy.GalaxyPrefix)
                .NotEmpty()
                .WithMessage("Please Specify a Prefix.");
            RuleFor(galaxy => galaxy.Author)
                .NotEmpty()
                .WithMessage("Please Specify an Author.");
            RuleFor(galaxy => galaxy.Version)
                .NotEmpty()
                .WithMessage("Please Specify a Version.");
            RuleFor(galaxy => galaxy.Date)
                .NotEmpty()
                .WithMessage("Please Specify a Date.");
            RuleFor(galaxy => galaxy.Save)
                .NotEmpty()
                .WithMessage("Please Specify a Save.");
            RuleFor(galaxy => galaxy.MinRandomBelts)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please Specify a Minimum of random belts.");
            RuleFor(galaxy => galaxy.MaxRandomBelts)
                .NotEmpty()
                .GreaterThan(galaxy => galaxy.MinRandomBelts)
                .WithMessage("Please Specify a Maximum of random belts.");
            RuleFor(galaxy => galaxy.Description)
                .NotEmpty().
                WithMessage("Please add a description");
        }
    }
}
