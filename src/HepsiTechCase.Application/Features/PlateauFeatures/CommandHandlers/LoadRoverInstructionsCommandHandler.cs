using HepsiTechCase.Application.Features.PlateauFeatures.Commands;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.CommandHandlers;

public class LoadRoverInstructionsCommandHandler : IRequestHandler<LoadRoverInstructionsCommand>
{
    public Task<Unit> Handle(LoadRoverInstructionsCommand request, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request.Plateau);
        ArgumentNullException.ThrowIfNull(request.RoverId);
        ArgumentNullException.ThrowIfNull(request.RoverInstructionsInput);
        request.Plateau.LoadRoverInstructions(request.RoverId, request.RoverInstructionsInput.ToCharArray());

        return Task.FromResult(Unit.Value);
    }
}