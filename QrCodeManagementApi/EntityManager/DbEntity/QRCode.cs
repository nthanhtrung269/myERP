using System;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbEntity
{
    public partial class QRCode
    {
        public QRCode()
        {
            Statictics = new HashSet<Statictic>();
            VCardDetails = new HashSet<VCardDetail>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string TargetUrl { get; set; }
        public string StatisticsUrl { get; set; }
        public string Foreground { get; set; }
        public string Background { get; set; }
        public string EmbedLogo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public int? TemplateId { get; set; }
        public string Filename { get; set; }
        public byte QrType { get; set; }
        public bool IsArchived { get; set; }
        public int? EmbedLogoId { get; set; }
        public string EmbedFrame { get; set; }
        public int? EmbedFrameId { get; set; }

        public virtual ICollection<Statictic> Statictics { get; set; }
        public virtual ICollection<VCardDetail> VCardDetails { get; set; }
    }
}
