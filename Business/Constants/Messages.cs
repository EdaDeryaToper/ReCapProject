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
        public static string CarImageExceed = "En fazla 5 görsel ekleyebilirsin";
        public static string DefaultImage = "Default fotoğraf eklendi";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";

        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Access Token oluşturuldu";
    }
}
