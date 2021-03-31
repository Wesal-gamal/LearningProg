namespace Attendleave.Erp.Core.APIUtilities
{
    public interface IActionResultResponseHandler
    {
        IRepositoryResult GetResult(IRepositoryActionResult repositoryActionResult);
    }
}
