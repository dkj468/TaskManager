using Domain;
using FluentValidation;
using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class CreateActivity
    {
        public class Command: IRequest<Unit>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
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
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
