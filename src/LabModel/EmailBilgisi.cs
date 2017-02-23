using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabKhufu.Model
{
    public class EmailBilgisi
    {
        public Guid ID { get; set; }

        public FihristTipi Tip { get; set; }

        public string Unvan { get; set; }

        public string EMail { get; set; }

    }
}
