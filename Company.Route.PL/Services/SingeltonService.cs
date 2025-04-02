
namespace Company.Route.PL.Services
{
    public class SingeltonService : ISingeltonService
    {
        public Guid Guid { get; set; }

        public SingeltonService()
        {
            Guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
