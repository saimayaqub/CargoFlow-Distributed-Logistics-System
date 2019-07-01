using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.APIMessages;

namespace Web.ViewModels
{
    public class QuotationViewModel
    {
        public QuotationViewModel()
        {
            //Booking = new HashSet<Booking>();
            CargoDetail = new HashSet<CargoDetail>();
            DestinationCharges = new HashSet<DestinationCharges>();
            DestinationChargesDd = new HashSet<DestinationChargesDd>();
            //InstructionsForm = new HashSet<InstructionsForm>();
            OriginCharges = new HashSet<OriginCharges>();
        }
        [Key]
        public int QuotationId { get; set; }
        public DateTime? DateOfInquiry { get; set; }
        public string TypeOfTransport { get; set; }
        public int? ImportOrExport { get; set; }
        public int? StatusId { get; set; }

        //public virtual Customer Customer { get; set; }
        //public virtual Operator Operator { get; set; }
        //public virtual CargoStatusList Status { get; set; }

        //public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<CargoDetail> CargoDetail { get; set; }
        public virtual ICollection<DestinationCharges> DestinationCharges { get; set; }
        public virtual ICollection<DestinationChargesDd> DestinationChargesDd { get; set; }
        //public virtual ICollection<InstructionsForm> InstructionsForm { get; set; }
        public virtual ICollection<OriginCharges> OriginCharges { get; set; }
    }
}
