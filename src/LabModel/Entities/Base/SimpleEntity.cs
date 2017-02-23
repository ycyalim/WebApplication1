using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace LabKhufu.Model.Entities.Base
{

    public abstract class SimpleEntity : Entity
    {        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kod Boş Geçilemez!")]
        [StringLength(50)]
        [Column(Order = 2)]
        public virtual string Kod { get; set; }

        [StringLength(50)]
        [Column(Order = 3)]
        public virtual string Aciklama { get; set; }

        [Column(Order = 4)]
        public virtual int SiraNo { get; set; }

        #region IDXDataErrorInfo Members

        public void GetError(ErrorInfo info)
        {

        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (propertyName == "Kod" && string.IsNullOrWhiteSpace(Kod))
                info.ErrorText = "Kod Boş Olamaz!";
        }
        #endregion

        public string KodAciklama
        {
            get
            {
                return (Kod + " " + (Aciklama ?? "")).Trim();
            }
        }

        public override string ToString()
        {
            return KodAciklama;

            //if (Aciklama == null)
            //    return Kod;
            //else
            //    return Aciklama;
        }

    }

}
