using FluentValidation;
using FluentValidation.Results;

namespace MinCode.Framework.Commands
{
  /// <summary>
  /// A validator for a command based on FluentValidation
  /// </summary>
  /// <typeparam name="TCommand">Type of command</typeparam>
  public abstract class CommandValidator<TCommand>
    : AbstractValidator<TCommand>
    , ICommandValidator<TCommand>
    where TCommand : class, ICommand
  {
    /// <summary>
    /// Basic rules to execute
    /// </summary>
    /// <remarks>
    /// This are checks that should also be done in the user interface
    /// No Database or HTTP calls should be done here;
    /// Think of simple checks like checks for nulls, empty, enumerations
    /// Will return an HTTP 400
    /// </remarks>
    protected Action? BasicRules = null;
    /// <summary>
    /// Extended rules that are checked when all basic rules are passed
    /// </summary>
    /// <remarks>
    /// For example checks for duplicates against the database.
    /// Will return an HTTP 400
    /// </remarks>
    protected Action? ExtendedRules = null;
    /// <summary>
    /// Unprocessable rules that are checked if all basic and extended rules are passed
    /// </summary>
    /// <remarks>
    /// This should validate and return understandable messages to the user.
    /// Will return an HTTP 422
    /// </remarks>
    protected Action? UnprocessableRules = null;

    /// <summary>
    /// Constructor
    /// </summary>
    public CommandValidator()
    {
      SetRules();
      if (this.BasicRules != null)
      {
        RuleSet(nameof(CommandValidatorRuleSets.BasicRuleSet), () => this.BasicRules());
      }
      if (this.ExtendedRules != null)
      {
        RuleSet(nameof(CommandValidatorRuleSets.ExtendedRuleSet), () => this.ExtendedRules());
      }
      if (this.UnprocessableRules != null)
      {
        RuleSet(nameof(CommandValidatorRuleSets.UnprocessableRuleSet), () => this.UnprocessableRules());
      }
    }

    /// <summary>
    /// Method that must be overridden that sets the different rule sets
    /// </summary>
    protected abstract void SetRules();

    /// <summary>
    /// Default prevalidate check
    /// </summary>
    /// <param name="context"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    protected override bool PreValidate(ValidationContext<TCommand> context, ValidationResult result)
    {
      if (context.InstanceToValidate == null)
      {
        result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));
        return false;
      }
      return true;
    }

    /// <summary>
    /// Overrides AbstractValidator
    /// Will check rule sets one by one
    /// </summary>
    /// <param name="command">the command to validate</param>
    /// <param name="cancellation">cancellation token</param>
    /// <returns></returns>
    public new async Task<ValidationResult> ValidateAsync(TCommand command, CancellationToken cancellation)
    {
      var validationResult = await this.ValidateAsync(command,
        options => options.IncludeRuleSets(nameof(CommandValidatorRuleSets.BasicRuleSet)), cancellation);
      if (!validationResult.IsValid)
      {
        return validationResult;
      }
      validationResult = await this.ValidateAsync(command,
        options => options.IncludeRuleSets(nameof(CommandValidatorRuleSets.ExtendedRuleSet)), cancellation);
      if (!validationResult.IsValid)
      {
        return validationResult;
      }
      validationResult = await this.ValidateAsync(command,
        options => options.IncludeRuleSets(nameof(CommandValidatorRuleSets.UnprocessableRuleSet)), cancellation);
      if (!validationResult.IsValid)
      {
        return validationResult;
      }

      return await this.ValidateAsync(command);
    }
  }
}
