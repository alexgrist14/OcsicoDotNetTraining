namespace Kawaii.Domain.Contracts
{
    public interface IEntityModel<T>
    {
        T Id { get; set; }
    }
}
