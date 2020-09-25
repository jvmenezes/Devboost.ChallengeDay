using Devboost.ChallengeDay.Data.Contexts;
using Devboost.ChallengeDay.Domain.Entities;

namespace Devboost.ChallengeDay.Data.Repositories
{
    public class TransacaoRepository : Repository<Entity>
    {
        private MongoDbContext<Transacao> _context;
        public TransacaoRepository(MongoDbContext<Transacao> context): base(context)
        {
            _context = context;
        }

    }
}
