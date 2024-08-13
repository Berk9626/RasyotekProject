using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Business.DTOs
{
    public class ResultPersonelDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }  // RadioButton için
        public bool Zimmet { get; set; }  // Checkbox için
        public List<string> Mezuniyet { get; set; }  // Okul alanı
    }
}
