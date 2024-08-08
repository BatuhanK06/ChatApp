using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace WebApplication3.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessages()
        {
            List<mesajlar> gelenler = new List<mesajlar>();

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
                                mesajlar mesaj = new mesajlar();
                                mesaj.name = veriOkuyucu.GetString(1);
                                mesaj.message = veriOkuyucu.GetString(2);

                                gelenler.Add(mesaj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            return Ok(gelenler);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult PostMessage([FromBody] mesajlar mesaj)
        {
            if (mesaj == null || string.IsNullOrEmpty(mesaj.name) || string.IsNullOrEmpty(mesaj.message))
            {
                return BadRequest(new { message = "Invalid message data." });
            }

            try
            {
                string baglantistring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Messages;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                using (SqlConnection baglanti = new SqlConnection(baglantistring))
                {
                    baglanti.Open();
                    string sqlIfadesi = "INSERT INTO MESAJLAR (name, message) VALUES (@name, @message);";
                    using (SqlCommand myCmd = new SqlCommand(sqlIfadesi, baglanti))
                    {
                        myCmd.Parameters.AddWithValue("@name", mesaj.name);
                        myCmd.Parameters.AddWithValue("@message", mesaj.message);

                        myCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error: " + ex.Message });
            }

            return Ok(new { message = "Message added successfully." });
        }

        public class mesajlar
        {
            public string name { get; set; }
            public string message { get; set; }
        }
    }
}
