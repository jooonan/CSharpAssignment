namespace Business.Helpers;

public static class IdGenerator
{
    public static Guid GenerateId()
    {
        return Guid.NewGuid();
    }
}