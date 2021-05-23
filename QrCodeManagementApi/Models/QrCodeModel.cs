using QrCodeManagementApi.EntityManager.DbEntity;
using System;
using System.Collections.Generic;

namespace QrCodeManagementApi.Models
{
    public class QrCodeModel
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string TargetUrl { get; set; }

        public string StatisticsUrl { get; set; }

        public string Foreground { get; set; }

        public string Background { get; set; }

        public DateTime CreatedDate => DateTime.Now;

        public string UserId { get; set; }

        public int? TemplateId { get; set; }

        public string Filename { get; set; }

        public byte QrType { get; set; }

        public bool IsArchived { get; set; }

        public string EmbedLogo { get; set; }

        public int? EmbedLogoId { get; set; }

        public int? SelectedLogoId { get; set; }

        public int? SelectedTemplateId { get; set; }

        public string EmbedFrame { get; set; }

        public int? EmbedFrameId { get; set; }

        public int? SelectedFrameId { get; set; }

        public IList<Logo> Logos { get; set; }

        public IList<Frame> Frames { get; set; }

        public IList<Template> Templates { get; set; }
    }
}
