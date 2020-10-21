namespace IronFit.Domain.Shared.Interfaces
{
    public interface IUnityOfWork
    {
        bool Commit();
    }
}
