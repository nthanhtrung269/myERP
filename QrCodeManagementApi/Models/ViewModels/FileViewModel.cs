using System.Web;

namespace QrCodeManagementApi.Models.ViewModels
{
    public class FileViewModel : QrCodeModel
    {
        public string FileType { get; set; }

        public HttpPostedFileBase FileUpload { get; set; }
    }
}
