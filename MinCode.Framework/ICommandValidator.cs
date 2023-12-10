using FluentValidation;

namespace MinCode.Framework
{
  /// <summary>
  /// Validates a command
  /// </summary>
  /// <typeparam name="TCommand">Type of the command</typeparam>
  public interface ICommandValidator<in TCommand>
    : IValidator<TCommand>
    where TCommand : ICommand
  {
  }
}
