using Domain;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IUpdateCodeStatusService
    {
        void UpdateStatus(string key, CodeStatus status);
    }
}