using Karimaneh.Application.Interfaces;
using Karimaneh.Infrastructure.Persistence;

namespace Karimaneh.Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly KarimanehDbContext _context;

        public RequestManager(KarimanehDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            var request = await _context.
                FindAsync<ClientRequest>(id);

            return request != null;
        }

        public async Task CreateRequestForCommandAsync<T>(Guid id)
        {
            var exists = await ExistAsync(id);

            var request = exists ?
                //TODO: Fix This
                //throw new DomainException($"Request with {id} already exists") :
                throw new ArgumentException($"Request with {id} already exists") :
                new ClientRequest()
                {
                    Id = id,
                    Name = typeof(T).Name,
                    Time = DateTime.UtcNow
                };

            _context.Add(request);

            await _context.SaveChangesAsync();
        }
    }
}
