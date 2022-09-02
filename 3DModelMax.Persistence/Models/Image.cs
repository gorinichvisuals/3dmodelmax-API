using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public int _3DmodelId { get; set; }
        public _3DModel _3DModel { get; set; }
        public string File { get; set; }
    }
}