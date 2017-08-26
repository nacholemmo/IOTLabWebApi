using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace IOTLabWebApi.Core.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(255)]
        public string MoreInfo { get; set; }

        [Required]
        [StringLength(255)]
        public string Microcontroller { get; set; }

        [Required]
        [StringLength(255)]
        public string DigitalIOPins { get; set; }
        [Required]
        [StringLength(255)]
        public string AnalogInputPins { get; set; }

        [Required]
        [StringLength(255)]
        public string PWMDigitalIOPins { get; set; }

        public ICollection<Device> Devices { get; set; }

        public Model()
        {
            Devices=new Collection<Device>();
        }
    }
}   