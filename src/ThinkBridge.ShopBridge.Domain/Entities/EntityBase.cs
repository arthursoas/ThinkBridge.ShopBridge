using System.ComponentModel.DataAnnotations.Schema;

namespace ThinkBridge.ShopBridge.Domain.Entities
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Time an entity was created
        /// </summary>
        public DateTimeOffset CreateDate { get; set; }

        /// <summary>
        /// Time an entity was updated
        /// </summary>
        public DateTimeOffset UpdateDate { get; set; }
    }
}
