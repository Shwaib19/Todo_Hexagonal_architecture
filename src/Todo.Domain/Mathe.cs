namespace Todo.Domain;

public class Mathe
{
    public static int Factorial(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
        if (value > 20)
        {
            throw new OverflowException();
        }
        if (value == 0 || value == 1)
        {
            return 1;
        }
        return value * Factorial(value - 1);
    }
}

public class MatheService 
{
    private readonly IExternalService _externalService;
    public MatheService(IExternalService externalService)
    {
        _externalService = externalService;
    }
    public int Factorial(int value)
    {
        
        if(_externalService.WorkToday())
        {
            return Mathe.Factorial(value);
            
        }
        throw new Exception("Does Not Work Today");
    }
}

public interface IExternalService
{
    public bool WorkToday();
}


public class FakeExternalServiceWorkingToday( bool value) :IExternalService
{
    public bool WorkToday()
    {
        return value;
    }
}
