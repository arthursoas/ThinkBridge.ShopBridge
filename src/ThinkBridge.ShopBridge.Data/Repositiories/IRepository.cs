namespace ThinkBridge.ShopBridge.Data.Repositiories
{
    public interface IRepository
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
