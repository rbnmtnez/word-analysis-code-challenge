using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.Domain.Commands;

namespace WordAnalysis.Domain.Services
{
    public interface ICommandDispatcher<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task DispatchAsync(TCommand command);
    }
}
