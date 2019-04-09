using System;
using System.Threading.Tasks;

namespace Common
{
    public interface ICommandBus
    {
        Task<Result> Execute(ICommand c);

        void SubscribeToCommandExecutionResults(Action<ICommand, Result> callbackOnNewCommandExecutionResult);
    }
}