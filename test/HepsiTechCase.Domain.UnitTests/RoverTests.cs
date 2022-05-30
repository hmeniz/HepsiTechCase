using HepsiTechCase.Application.Features.PlateauFeatures.Commands;
using HepsiTechCase.Console;
using HepsiTechCase.Domain.Aggreagates.Plateau;
using HepsiTechCase.Domain.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HepsiTechCase.Domain.UnitTests;

public class RoverTests
{
    [Test]
    [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
    [TestCase("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
    public async Task TurnAndMoves(
         string plateauSizeInput,
         string roverPositionInput,
         string roverInstructionsInput,
         string expectedOutput)
    {
        IServiceProvider provider = ServiceProviderFactory.GetServiceProvider();
        IMediator mediator = provider.GetService<IMediator>();

        Plateau plateau = await mediator.Send(new CreatePlateauCommand()
        {
            SizeInput = plateauSizeInput
        });
        Guid roverId = await mediator.Send(new CreateRoverCommand() { 
            Plateau = plateau, 
            RoverPositionInput = roverPositionInput 
        });

        await mediator.Send(new LoadRoverInstructionsCommand() { 
            Plateau = plateau,
            RoverId = roverId, 
            RoverInstructionsInput = roverInstructionsInput 
        });

        RoverPosition roverPosition = await mediator.Send(new RunRoverInstructionsCommand()
        {
            Plateau = plateau,
            RoverId = roverId
        });

        var actualOutput = $"{roverPosition.X} {roverPosition.Y} {roverPosition.Direction.GetValue()}";

        Assert.AreEqual(expectedOutput, actualOutput);
    }
}