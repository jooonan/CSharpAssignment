namespace Business.Helpers;

public static class IdGenerator
{

    public static string GenerateId() => Guid.NewGuid().ToString();
}