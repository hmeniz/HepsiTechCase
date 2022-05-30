namespace HepsiTechCase.Domain.Exceptions;

public class InputNotAppropriateException : Exception
{
    public InputNotAppropriateException(string inputMessage)
       : base($"{inputMessage} not appropriate for plateau axises")
    {
    }
}