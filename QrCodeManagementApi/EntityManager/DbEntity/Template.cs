namespace QrCodeManagementApi.EntityManager.DbEntity
{
    public partial class Template
    {
        public int Id { get; set; }
        public string Foreground { get; set; }
        public string Background { get; set; }
        public string EmbedLogo { get; set; }
        public string UserId { get; set; }
    }
}
