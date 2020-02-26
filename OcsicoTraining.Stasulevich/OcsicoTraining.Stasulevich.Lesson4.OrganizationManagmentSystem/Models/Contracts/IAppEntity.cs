namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts
{
    public interface IAppEntity<T>
    {
        T Id { get; set; }
    }
}
