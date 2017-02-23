
namespace LabKhufu.Model
{
    public enum FihristTipi
    {
        Fihrist = 0,
        Kurum = 1,
    }

    public class EnumNumuneTipleri
    {
        public static EnumNumuneTipi[] Gida
        {
            get { return new EnumNumuneTipi[] { EnumNumuneTipi.Gıda, EnumNumuneTipi.Swap, EnumNumuneTipi.Sıvı }; }
        }

        public static EnumNumuneTipi[] HavuzSuyu
        {
            get { return new EnumNumuneTipi[] { EnumNumuneTipi.HavuzSuyu }; }
        }
    }

    public enum EnumNumuneAlimTipi
    {
        Gıda = 64,
        HavuzSuyu = 128,
        Diğer = 2048
    }

    public enum EnumNumuneTipi
    {
        Gıda = EnumNumuneAlimTipi.Gıda | 1,
        Swap = EnumNumuneAlimTipi.Gıda | 2,
        Sıvı = EnumNumuneAlimTipi.Gıda | 4,
        HavuzSuyu = EnumNumuneAlimTipi.HavuzSuyu | 1,
        Diğer = EnumNumuneAlimTipi.Diğer | 1
    }

}
