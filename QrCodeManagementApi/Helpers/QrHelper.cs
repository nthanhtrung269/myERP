using QrCodeManagementApi.Constants;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace QrCodeManagementApi.Helpers
{
    public class QrHelper
    {
        public static string GetQrImageSource(string qrCodeId, string content, string foreground, string background, string logo)
        {
            if (!string.IsNullOrEmpty(qrCodeId))
            {
                content = string.Empty;
            }

            return $"/webhandler/getcode.ashx?i={qrCodeId}&c={content}&b={background.Replace("#", "%23")}&f={foreground.Replace("#", "%23")}&l={logo}";
        }

        public static QrFileType GetFileTypeFromFileName(string filename)
        {
            return (!string.IsNullOrEmpty(filename) && Path.GetExtension(filename).ToLower() == ".pdf" ? QrFileType.PDF : QrFileType.Image);
        }

        public static bool IsOwnerOfQr(string qrId, string userId)
        {
            var qrCode = new QrCodeService().GetQrCodeById(qrId);
            return qrCode != null && qrCode.UserId.Equals(userId);
        }

        public static bool IsOwnerOfTemplate(int templateId, string userId)
        {
            var template = new TemplateService().GetQrTemplateById(templateId);
            return template != null && template.UserId.Equals(userId);
        }

        public static bool IsOwnerOfLogo(int logoId, string userId)
        {
            var logo = new LogoService().GetLogoById(logoId);
            return logo != null && logo.UserId.Equals(userId);
        }

        public static Image ResizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            if (sourceWidth == newWidth)
            {
                return imgPhoto;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercentW = newWidth / (float)sourceWidth;
            float nPercentH = newHeight / (float)sourceHeight;
            float nPercent;

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = Convert.ToInt16((newWidth - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = Convert.ToInt16((newHeight - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }

        public static Image ResizeImage(Image image, int newHeight, int newWidth)
        {
            Bitmap newImage = new Bitmap(newHeight, newWidth);
            Graphics g = Graphics.FromImage(newImage);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, newHeight, newWidth);
            g.Dispose();

            return newImage;
        }

        public static long GetJavascriptTimestamp(DateTime input)
        {
            TimeSpan span = new TimeSpan(DateTime.Parse("1/1/1970").Ticks);
            DateTime time = input.Subtract(span);
            return time.Ticks / 10000;
        }

        public static string CorrectUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            Uri uri = new UriBuilder(url).Uri;
            // Reference: https://stackoverflow.com/questions/7624987/whats-the-difference-between-uri-tostring-and-uri-absoluteuri
            return uri.ToString();
        }

        // Reference: https://stackoverflow.com/questions/6724840/how-can-i-truncate-my-strings-with-a-if-they-are-too-long
        public static string Truncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        // Reference: https://www.w3.org/2002/12/cal/vcard-notes.html
        // https://docs.fileformat.com/email/vcf/
        public static string GetVCardContent(VCardDetail vCardDetail)
        {
            var sb = new StringBuilder();
            sb.Append("BEGIN:VCARD\r\n");
            sb.Append("VERSION:3.0\r\n");
            sb.Append($"N:{vCardDetail.LastName};{vCardDetail.FirstName}\r\n");
            sb.Append($"FN:{vCardDetail.FirstName} {vCardDetail.LastName}\r\n");

            if (!string.IsNullOrEmpty(vCardDetail.Company))
            {
                sb.Append($"ORG:{vCardDetail.Company}\r\n");
            }

            if (!string.IsNullOrEmpty(vCardDetail.JobTitle))
            {
                sb.Append($"TITLE:{vCardDetail.JobTitle}\r\n");
            }

            if (!string.IsNullOrEmpty(vCardDetail.MobileNumber))
            {
                sb.Append($"TEL;WORK;VOICE:{vCardDetail.MobileNumber}\r\n");
            }

            if (!string.IsNullOrEmpty(vCardDetail.Phone))
            {
                sb.Append($"TEL;CELL:{vCardDetail.Phone}\r\n");
            }

            if (!string.IsNullOrEmpty(vCardDetail.Fax))
            {
                sb.Append($"TEL;FAX:{vCardDetail.Fax}\r\n");
            }

            sb.Append($"ADR;WORK:;;{vCardDetail.Street};{vCardDetail.City};{vCardDetail.State};{vCardDetail.Zipcode};{vCardDetail.Country}\r\n");

            if (!string.IsNullOrEmpty(vCardDetail.Email))
            {
                sb.Append($"EMAIL;WORK;INTERNET:{vCardDetail.Email}\r\n");
            }

            if (!string.IsNullOrEmpty(vCardDetail.Website))
            {
                sb.Append($"URL:{CorrectUrl(vCardDetail.Website)}\r\n");
            }

            if (!string.IsNullOrEmpty(vCardDetail.About))
            {
                sb.Append($"NOTE:{vCardDetail.About}\r\n");
            }

            sb.Append("REV:2008-04-24T19:52:43Z\r\n");
            sb.Append("END:VCARD\r\n");

            return sb.ToString();
        }
    }
}