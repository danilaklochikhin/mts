using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mts.Domain.Entities
{
    public class TarifsBase 
    {
        [Required (ErrorMessage ="Введите название тарифа")]
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Интернет")]
        public string Internet { get; set; }
        [Display(Name = "Стоимость")]
        public string Price { get; set; }
    }
}
