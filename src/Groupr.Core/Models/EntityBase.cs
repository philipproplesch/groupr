using ServiceStack.DataAnnotations;

namespace Groupr.Core.Models
{
    public class EntityBase
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; } 
    }
}