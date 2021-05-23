using System;

namespace QrCodeManagementApi.EntityManager.DbEntity
{
    public partial class Statictic
    {
        public int Id { get; set; }
        public string QrId { get; set; }
        public string Device { get; set; }
        public string Os { get; set; }
        public string LongTitude { get; set; }
        public string LatTitude { get; set; }
        public DateTime? ScanDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    
        public virtual QRCode QRCode { get; set; }
    }
}
