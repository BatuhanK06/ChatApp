using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

[Authorize]
public class IndexModel : PageModel
{
    public List<mesajlar> gelenler = new List<mesajlar>();
    public void OnGet()
    {
        try
        {
            string baglantistring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Messages;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection baglanti = new SqlConnection(baglantistring))
            {
                baglanti.Open();
                string sqlIfadesi = "SELECT * FROM MESAJLAR;";
                using (SqlCommand myCmd = new SqlCommand(sqlIfadesi, baglanti))
                {
                    using (SqlDataReader veriOkuyucu = myCmd.ExecuteReader())
                    {
                        while (veriOkuyucu.Read())
                        {
                            mesajlar mesajlar = new mesajlar();
                            mesajlar.id = "" + veriOkuyucu.GetInt16(0);
                            mesajlar.name = "" + veriOkuyucu.GetInt16(1);
                            mesajlar.message = "" + veriOkuyucu.GetInt16(2);

                            gelenler.Add(mesajlar);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("oluþan hata=" + ex.ToString());
        }
    }

    public class mesajlar
    {
        public string id;
        public string name;
        public string message;
    }

}