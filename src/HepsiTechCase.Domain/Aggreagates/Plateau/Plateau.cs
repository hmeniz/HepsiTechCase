using HepsiTechCase.Domain.Enums;

namespace HepsiTechCase.Domain.Aggreagates.Plateau;

public class Plateau : IAggregateRoot
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public List<Rover> Rovers { get; private set; }

    public Plateau(int x, int y)
    {
        X = x;
        Y = y;
        this.Rovers = new();
    }

    public Guid AddRover(Directions direction, int x, int y)
    {
        Rover rover = new(this, new RoverPosition(this, direction, x, y));
        this.Rovers.Add(rover);

        return rover.Id;
    }

    public void LoadRoverInstructions(Guid roverId, char[] instructions)
    {
        Rover rover = this.Rovers.First(x => x.Id == roverId);
        rover.LoadInstructions(instructions);
    }

    public void MoveRover(Guid roverId)
    {
        Rover rover = this.Rovers.First(x => x.Id == roverId);
        rover.Move();
    }

    public void TurnRoverLeft(Guid roverId)
    {
        Rover rover = this.Rovers.First(x => x.Id == roverId);
        rover.TurnLeft();
    }

    public void TurnRoverRight(Guid roverId)
    {
        Rover rover = this.Rovers.First(x => x.Id == roverId);
        rover.TurnRight();
    }
}