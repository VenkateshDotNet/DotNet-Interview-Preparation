namespace PracticeProject
{
    public interface IAuth
    {
        string GenerateToken(string username, string password);

    }
}
