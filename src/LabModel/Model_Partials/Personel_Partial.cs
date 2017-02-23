using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;

namespace LabKhufu.Model.Entities
{
    public partial class Personel
    {
        public override string ToString()
        {
            return AdSoyad;
        }

        [NotMapped]
        public byte[] Kase
        {
            get
            {
                if (Image == null)
                    Image = new PersonelImage();
                return Image.Kase;
            }

            set
            {
                if (Image == null)
                    Image = new PersonelImage();
                Image.Kase = value;
            }
        }

        [NotMapped]
        public byte[] KaseImzali
        {
            get
            {
                if (Image == null)
                    Image = new PersonelImage();
                return Image.KaseImzali;
            }

            set
            {
                if (Image == null)
                    Image = new PersonelImage();
                Image.KaseImzali = value;
            }
        }

        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return ((Ad ?? "") + " " + (Soyad ?? "")).Trim();
            }
        }

        [NotMapped]
        private Dictionary<string, Guid> _yetkiler;

        public void ResetYetkiler()
        {
            _yetkiler = null;
        }

        public bool Yetkilimi(string yetkiKod)
        {
            if (_yetkiler == null)
            {
                _yetkiler = new Dictionary<string, Guid>();
                foreach (Yetki yetki in Yetkiler)
                    _yetkiler.Add(yetki.Kod, yetki.ID);
            }

            return _yetkiler.ContainsKey(yetkiKod);
        }
    }

    
}
