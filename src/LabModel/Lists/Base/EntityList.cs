using System;

namespace LabKhufu.Model.Lists
{
    public class EntityList
    {
        public Guid ID { get; set; }

        public bool KullanimDisi { get; set; }

        public Guid? Ekleyen_ID { get; set; }
        public string Ekleyen { get; set; }
        public DateTime? EklemeTarihi { get; set; }

        public Guid? Degistiren_ID { get; set; }
        public string Degistiren { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
    }
}
