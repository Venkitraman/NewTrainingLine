namespace TrainingLine.Repository
{
    public interface ILoginRepository
    {
        bool Validate(string username, string password);
    }
}