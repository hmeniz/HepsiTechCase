namespace HepsiTechCase.Domain.Constants;

public class Instruction
{
    public const char Left = 'L';
    public const char Right = 'R';
    public const char Move = 'M';

    public static bool IsValid(char instruction)
    {
        return instruction == Left || instruction == Right || instruction == Move;
    }
}