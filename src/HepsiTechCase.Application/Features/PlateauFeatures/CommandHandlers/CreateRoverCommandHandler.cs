using HepsiTechCase.Application.Factories.PlateauFactories;
using HepsiTechCase.Application.Features.PlateauFeatures.Commands;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.CommandHandlers;

public class CreateRoverCommandHandler : IRequestHandler<CreateRoverCommand, Guid>
{
    public Task<Guid> Handle(CreateRoverCommand request, CancellationToken ct)
    {
        var (direction, x, y) = RoverPositionFactory.GetPosition(request.RoverPositionInput);
        Guid roverId = request.Plateau.AddRover(direction, x, y);

        return Task.FromResult(roverId);
    }
}