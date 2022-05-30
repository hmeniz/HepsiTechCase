using HepsiTechCase.Application.Features.PlateauFeatures.Commands;
using HepsiTechCase.Domain.Aggreagates.Plateau;
using HepsiTechCase.Domain.Constants;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.CommandHandlers;

public class RunRoverInstructionsCommandHandler : IRequestHandler<RunRoverInstructionsCommand, RoverPosition>
{
    public async Task<RoverPosition> Handle(RunRoverInstructionsCommand request, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request.Plateau);
        ArgumentNullException.ThrowIfNull(request.Plateau.Rovers);

        Rover rover = request.Plateau.Rovers.First(x => x.Id == request.RoverId);
        ArgumentNullException.ThrowIfNull(rover.Instructions);
        Queue<char> instructions = rover.Instructions;
        while (instructions.Count > 0)
        {
            char instruction = instructions.Dequeue();
            switch (instruction)
            {
                case Instruction.Left:
                    request.Plateau.TurnRoverLeft(request.RoverId);
                    break;
                case Instruction.Right:
                    request.Plateau.TurnRoverRight(request.RoverId);
                    break;
                case Instruction.Move:
                    request.Plateau.MoveRover(request.RoverId);
                    break;
                default:
                    break;
            }
        }

        return await Task.FromResult(rover.CurrentPosition);
    }
}