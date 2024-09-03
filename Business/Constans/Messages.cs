using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi!";
        public static string ProductNameInValid = "Ürün ismi geçersiz!";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string AllbyCategoryIdListed = " numaralı Kategori İd'ye sahip ürünler listelendi";
        public static string ProductCountError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Aynı isimde birden fazla ürün bulunamaz";
        public static string CategoryLimitExceded = "Kategory limiti aşılmıştır.";
    }
}
