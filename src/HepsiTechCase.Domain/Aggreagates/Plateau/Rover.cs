using HepsiTechCase.Domain.Constants;

namespace HepsiTechCase.Domain.Aggreagates.Plateau;

public class Rover
{
    public Guid Id { get; private set; }
    public RoverPosition CurrentPosition { get; private set; }
    public Queue<char> Instructions { get; set; }

    internal Rover(Plateau plateau, RoverPosition currentPosition)
    {
        this.Id = Guid.NewGuid();
        this.CurrentPosition = currentPosition;
        this.Instructions = new();
    }

    internal void LoadInstructions(char[] instructions)
    {
        foreach (var instruction in instructions)
        {
            if (Instruction.IsValid(instruction) == false)
                throw new Exception($"{instruction} is not valid!");
            Instructions.Enqueue(instruction);
        }
    }

    internal void Move()
    {
        this.CurrentPosition.Move();
    }

    internal void TurnLeft()
    {
        this.CurrentPosition.TurnLeft();
    }

    internal void TurnRight()
    {
        this.CurrentPosition.TurnRight();      
    }
}