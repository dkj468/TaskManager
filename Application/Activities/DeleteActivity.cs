using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class DeleteActivity
    {
        public class Command: IRequest<Unit>
        {
            public Guid id { get; set; }
        }

        public class Handler:IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.id);
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
