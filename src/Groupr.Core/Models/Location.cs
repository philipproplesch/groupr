namespace Groupr.Core.Models
{
    public class Location : EntityBase
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string WebSite { get; set; }
        public int MaxAttendees { get; set; }
    }
}