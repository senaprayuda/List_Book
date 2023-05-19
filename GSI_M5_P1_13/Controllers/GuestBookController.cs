using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;

namespace GSI_M5_P1_13.Controllers
{
    public class GuestBookController : Controller
    {
        // GET: GuestBookController
        string connectionstring = "Data Source=LUTHFI; Integrated Security=true; Initial Catalog=GuestBookDB;";
        public ActionResult ListGuest()
        {
            var guestbook = new List<GSI_M5_P1_13.Models.GuestBookModel>();

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string query = "SELECT * FROM GuestBook";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                guestbook.Add(new Models.GuestBookModel()
                {
                    id = Int32.Parse(reader["id"].ToString()),
                    nama = reader["nama"].ToString(),
                    alamat = reader["alamat"].ToString(),
                    provinsi = reader["provinsi"].ToString(),
                    jenisKelamin = Int32.Parse(reader["jenisKelamin"].ToString()),
                    tanggalLahir = DateTime.Parse(reader["tanggalLahir"].ToString()),
                    pesan = reader["pesan"].ToString()
                });
            }
            return View(guestbook);
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: GuestBookController/Details/5
        public ActionResult Details(int id)
        {
            //Membuat object dari model GuestBook
            var guestbook = new Models.GuestBookModel();

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string query = "SELECT * FROM GuestBook WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            // Call ExecuteReader to return a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            guestbook.id = Int32.Parse(reader["id"].ToString());
            guestbook.nama = reader["nama"].ToString();
            guestbook.alamat = reader["alamat"].ToString();
            guestbook.provinsi = reader["provinsi"].ToString();
            guestbook.jenisKelamin = Int32.Parse(reader["jenisKelamin"].ToString());
            guestbook.tanggalLahir = DateTime.Parse(reader["tanggalLahir"].ToString());
            guestbook.pesan = reader["pesan"].ToString();


            return View(guestbook);
        }

        // GET: GuestBookController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: GuestBookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGuest(IFormCollection collection)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();

                string nama = collection["nama"];
                string alamat = collection["alamat"];
                string provinsi = collection["provinsi"];
                string jenisKelamin = collection["jenisKelamin"];
                string tanggalLahir = collection["tanggalLahir"];
                string pesan = collection["pesan"];

                string query = "INSERT INTO GuestBook VALUES('" + nama + "', '" + alamat + "', '" + provinsi + "', '" + jenisKelamin + "', '" + tanggalLahir + "', '" + pesan + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int result = cmd.ExecuteNonQuery();

                return RedirectToAction(nameof(ListGuest));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestBookController/Edit/5
        public ActionResult EditGuest(int id)
        {
            var guestbook = new Models.GuestBookModel();

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string query = "SELECT * FROM GuestBook WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            guestbook.id = Int32.Parse(reader["id"].ToString());
            guestbook.nama = reader["nama"].ToString();
            guestbook.alamat = reader["alamat"].ToString();
            guestbook.provinsi = reader["provinsi"].ToString();
            guestbook.jenisKelamin = Int32.Parse(reader["jenisKelamin"].ToString());
            guestbook.tanggalLahir = DateTime.Parse(reader["tanggalLahir"].ToString());
            guestbook.pesan = reader["pesan"].ToString();

            return View(guestbook);
        }

        // POST: GuestBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGuest(int id, IFormCollection collection)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();

                string nama = collection["nama"];
                string alamat = collection["alamat"];
                string provinsi = collection["provinsi"];
                string jenisKelamin = collection["jenisKelamin"];
                string tanggalLahir = collection["tanggalLahir"];
                string pesan = collection["pesan"];

                string query = "UPDATE GuestBook SET nama='" + nama + "', alamat='" + alamat + "', provinsi='" + provinsi + "', jenisKelamin='" + jenisKelamin + "', tanggalLahir='" + tanggalLahir + "', pesan='" + pesan + "' WHERE id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int result = cmd.ExecuteNonQuery();

                return RedirectToAction(nameof(ListGuest));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestBookController/Delete/5
        public ActionResult DeleteGuest(int id)
        {
            //Membuat object dari model GuestBook
            var guestbook = new Models.GuestBookModel();

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string query = "SELECT * FROM GuestBook WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            // Call ExecuteReader to return a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            guestbook.id = Int32.Parse(reader["id"].ToString());
            guestbook.nama = reader["nama"].ToString();
            guestbook.alamat = reader["alamat"].ToString();
            guestbook.provinsi = reader["provinsi"].ToString();
            guestbook.jenisKelamin = Int32.Parse(reader["jenisKelamin"].ToString());
            guestbook.tanggalLahir = DateTime.Parse(reader["tanggalLahir"].ToString());
            guestbook.pesan = reader["pesan"].ToString();


            return View(guestbook);

        }

        // POST: GuestBookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGuest(int id, IFormCollection collection)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();

                string query = "DELETE FROM GuestBook WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction(nameof(ListGuest));
            }
            catch
            {
                return View();
            }
        }
    }
}
