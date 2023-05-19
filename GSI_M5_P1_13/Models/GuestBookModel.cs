using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GSI_M5_P1_13.Models
{
    public class GuestBookModel
    {
        public int id { get; set; }

        [DisplayName("Nama")]
        [Required(ErrorMessage = "Nama harus di isi")]
        public string nama { get; set; }

        [DisplayName("Alamat")]
        [Required(ErrorMessage = "Alamat harus di isi")]
        public string alamat { get; set; }

        [DisplayName("Provinsi")]
        [Required(ErrorMessage = "Provinsi harus di isi")]
        public string provinsi { get; set; }

        [DisplayName("Jenis Kelamin")]
        [Required(ErrorMessage = "Jenis Kelamin harus di isi")]
        public int jenisKelamin { get; set; }

        [DisplayName("Tanggal Lahir")]
        [Required(ErrorMessage = "Tanggal lahir harus di isi")]
        [DataType(DataType.Date)]
        public DateTime tanggalLahir { get; set; }

        [DisplayName("Pesan")]
        [Required(ErrorMessage = "Pesan harus diisi")]
        public string pesan { get; set; }
    }
}
