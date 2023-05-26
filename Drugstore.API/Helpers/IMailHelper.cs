
using Drugstore.WEB.Shared.Responses;

namespace Drugstore.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);

    }
}
