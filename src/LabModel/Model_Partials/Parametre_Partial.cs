using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LabKhufu.Model.Entities
{
    public partial class Parametre
    {
        public string GetPdfFtpPath()
        {
            if (string.IsNullOrEmpty(PdfFtpPath))
                return "";
            else
                return PdfFtpPath + "/";
        }

        [NotMapped]
        public byte[] Antet
        {
            get
            {
                if (Image == null) 
                    Image = new ParametreImage();
                return Image.Antet;
            }

            set
            {
                if (Image == null)
                    Image = new ParametreImage();
                Image.Antet = value;
            }
        }

    }
}
