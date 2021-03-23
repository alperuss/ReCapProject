using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessAdded = "Ekleme başarılı.";
        public static string SuccessUpdated = "Güncelleme başarılı.";
        public static string SuccessDeleted = "Silme başarılı.";
        public static string SuccessListed = "Listeleme başarılı.";       
        public static string RentalInvalid="Kiralama başarısız.";
        public static string CarNameInvalid="Araba adı geçersiz.";
        public static string MaintenanceTime="Sistem bakımda";
        public static string NameInvalid="İsimi eksik ya da hatalı girdiniz.";
        public static string PasswordInvalid="Şifreniz en az 8 harf olmalıdır.";
        public static string CarCountOfBrandError = "Bir markada en fazla 10 araba olabilir";
        public static string ColorLimitExceded = "Araba renk sayısı 15'ten fazla";
        public static string CarImageLimitExceeded="Araba resmi sayısı 5'ten fazla olamaz";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered="Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
