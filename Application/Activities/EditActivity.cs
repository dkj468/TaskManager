using Domain;
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
    public class EditActivity
    {
        public class Command:IRequest<Unit>
        {
            public Guid id { get; set; }
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.id);
                activity.Name = request.Activity.Name ?? activity.Name;
                activity.Description = request.Activity.Description ?? activity.Description;
                activity.Tags = request.Activity.Tags ?? activity.Tags;
                
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
