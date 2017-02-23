using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class AnalizTipi : SimpleEntity
    {
        public override string ToString()
        {
            return Kod;
        }
    }
}
