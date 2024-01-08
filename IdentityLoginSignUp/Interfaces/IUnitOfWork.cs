namespace IdentityLoginSignUp.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> Commit();
    }
}
