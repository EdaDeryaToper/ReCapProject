using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarImageAdded = "Görsel eklendi";
        public static string CarAdded = "Araba eklendi";
        public static string CarInvalid = "Araba bilgileri eksik ya da yanlış";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Araba listelendi";
        public static string DelayReturnDate = "Araba teslim edilmedi";
        public static string CarReturned = "Araba kiralandı";
        public static string ImagePathError = "Bu görsel zaten var";
        internal static string CarImageExceed = "En fazla 5 görsel ekleyebilirsin";
    }
}
