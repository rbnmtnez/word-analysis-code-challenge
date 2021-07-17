using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.Domain.Commands
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<Task<TResult>>
    {
        Task<TResult> ExecuteAsync(TCommand command);
    }
}
