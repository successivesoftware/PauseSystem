using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class SendDeliveryMailRequest : BaseEntity
    {
        public int RequestId { get; set; }
        public int CustomerNr { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public bool Sent { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }
    }
}
