using HepsiTechCase.Application.Features.PlateauFeatures.Commands;
using HepsiTechCase.Console;
using HepsiTechCase.Domain.Aggreagates.Plateau;
using HepsiTechCase.Domain.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

Plateau plateau;

IServiceProvider provider = ServiceProviderFactory.GetServiceProvider();
IMediator mediator = provider.GetService<IMediator>();

//Plateau initialize
while (true)
{
    try
    {
        Console.Write("Plateau size(Ex: 5 5): ");
        string sizeInput = Console.ReadLine();
        plateau = await mediator.Send(new CreatePlateauCommand()
        {
            SizeInput = sizeInput
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Plateau size not appropriate. Please try again. \nException: {ex.Message}");
        continue;
    }

    break;
}

//Rover initialize and loading instructions
while (true)
{
    try
    {
        Console.Write("Rover's position(Ex: 1 3 N): ");
        string roverPositionInput = Console.ReadLine();

        Guid roverId = await mediator.Send(new CreateRoverCommand()
        {
            Plateau = plateau,
            RoverPositionInput = roverPositionInput
        });

        Console.Write("Instructions(Ex: LMLMRMM): ");
        var instructionsInput = Console.ReadLine();
        await mediator.Send(new LoadRoverInstructionsCommand()
        {
            Plateau = plateau,
            RoverId = roverId,
            RoverInstructionsInput = instructionsInput
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Rover infos is not appropriate. Please try again. \nException: {ex.Message}");
        continue;
    }

    Console.Write("Do you want to deploy another rover(Y-N)? ");
    var addAnother = Console.ReadLine();
    if (addAnother.ToUpper() != "Y")
        break;
}

Console.WriteLine("Expected Output: ");
foreach (var rover in plateau.Rovers)
{
    RoverPosition roverCurrentPosition = await mediator.Send(
        new RunRoverInstructionsCommand(){
            Plateau = plateau,
            RoverId = rover.Id
        });

    Console.WriteLine($"{roverCurrentPosition.X} {roverCurrentPosition.Y} {roverCurrentPosition.Direction.GetValue()}");
}
