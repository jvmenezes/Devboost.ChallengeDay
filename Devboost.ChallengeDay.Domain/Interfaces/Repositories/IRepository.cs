using Devboost.ChallengeDay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Domain.Interfaces.Repositories
{
    public interface IRepository<T>where T : TransacaoModel
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task<IEnumerable<T>> ObterPor(Expression<Func<T, bool>> predicate);
    }
}
