using HepsiTechCase.Application.Factories.PlateauFactories;
using HepsiTechCase.Application.Features.PlateauFeatures.Commands;
using HepsiTechCase.Domain.Aggreagates.Plateau;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.CommandHandlers;

public class CreatePlateauCommandHandler : IRequestHandler<CreatePlateauCommand, Plateau>
{
    public Task<Plateau> Handle(CreatePlateauCommand request, CancellationToken ct)
    {
        var (x, y) = PlateauSizeFactory.GetPosition(request.SizeInput);
        Plateau plateau = new(x, y);

        return Task.FromResult(plateau);
    }
}