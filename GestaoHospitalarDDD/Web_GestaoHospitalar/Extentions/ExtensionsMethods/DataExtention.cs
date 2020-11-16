using System;

namespace Web_GestaoHospitalar.Extentions.ExtensionsMethods
{
    public static class DataExtention
    {
        public static string ToBrazilianDate(this DateTime dateStandard)
        {
            return dateStandard.ToString("dd/MM/yyyy");
        }

        public static string ToBrazilianDateTime(this DateTime dateStandard)
        {
            return dateStandard.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
