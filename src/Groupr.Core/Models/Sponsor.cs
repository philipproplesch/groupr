namespace Groupr.Core.Models
{
    public class Sponsor : EntityBase
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}
