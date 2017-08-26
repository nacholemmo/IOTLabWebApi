using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOTLabWebApi.Core.Models
{
    [Table("Devices")]
    public class Device
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string DeviceComId { get; set; }

        //Propiedades de navegacion
        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}