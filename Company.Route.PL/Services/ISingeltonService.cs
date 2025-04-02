namespace Company.Route.PL.Services
{
    public interface ISingeltonService
    {
        public Guid Guid { get; set; }
        string GetGuid();
    }
}
