using System.Collections.Generic;

namespace Pierre.Models
{
    public class Tag
    {
        public Tag()
        {
            this.JoinEntities = new HashSet<FlavorTreat>();
        }

        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FlavorTreat> JoinEntities { get; set; }
    }
}