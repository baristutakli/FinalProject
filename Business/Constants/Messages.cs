using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // çok dil destekleyen halini devarchitecture da var
        public static string ProductAdded = "Urun eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Bakım zamanı";
        public static string ProductListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla ürün olabilir";

        public static string ProductNameAlreadyExists = "Bu ürün zaten mevcut";

        public static string AuthorizationDenied = "Yetkin yok!";

        public static string UserRegistered = "User Regşstered";

        public static string UserNotFound = "User not found";

        public static string PasswordError = "Password error";

        public static string SuccessfulLogin = "Successful login";

        public static string UserAlreadyExists = "User already exists";

        public static string AccessTokenCreated = "Access token created";
    }
}