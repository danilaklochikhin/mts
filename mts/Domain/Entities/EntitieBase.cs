using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mts.Domain.Entities
{
    public abstract class EntitieBase
    {
        protected EntitieBase() => DateAdded = DateTime.UtcNow;

        [Display(Name = "Название")]
        public virtual string Title { get; set; }
        [Display(Name = "Id")]
        public virtual string ID { get; set; }
        [Display(Name = "FIAS")]
        public virtual string Fias { get; set; }
        [Display(Name = "Интернет")]
        public virtual string Internet { get; set; }
        [Display(Name = "Стоимость")]
        public virtual string Price { get; set; }


        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

        [Required]
        [Key]
        public Guid Id { get; set; }
    }
}
