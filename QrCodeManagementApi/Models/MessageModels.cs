using System.Web.Mvc;

namespace QrCodeManagementApi.Models
{
    public class MessageModels
    {
        public string Title { get; set; }

        [AllowHtml]
        public string Message { get; set; }
    }
}