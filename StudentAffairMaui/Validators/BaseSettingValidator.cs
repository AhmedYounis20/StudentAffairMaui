

using FluentValidation;

namespace StudentAffairMaui;

public class BaseSettingValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : BaseSetting
{
    public BaseSettingValidator()
    {

        const int  nameMaxLength= 50;
        RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(TEntity)} name is required.");
        RuleFor(e => e.Name).MaximumLength(nameMaxLength).WithMessage($"{nameof(TEntity)} name max length is {nameMaxLength} character{(nameMaxLength<=1 ? ' ':'s')}");


    }
}