using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mts.Domain.Entities
{
    public class CitysBase
    {
        [Required(ErrorMessage = "Введите Id города")]
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Id")]
        public string ID_city { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "FIAS")]
        public string Fias { get; set; }
    }
}
