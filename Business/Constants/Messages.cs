using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        
    }
}
