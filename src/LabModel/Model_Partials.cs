namespace LabKhufu.Model.Entities
{
    public partial class RaporDizayn
    {
        public override string ToString()
        {
            if ((AltTip ?? "") == "")
                return Ad;
            else
                return Ad + " - " + AltTip;
        }

        public string DisplayMember
        {
            get { return this.ToString(); }
        }

    }
}
