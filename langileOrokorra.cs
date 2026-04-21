
using FluentFTP;
using MySql.Data.MySqlClient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Net;
namespace erronka3_1T
{
    internal class langileOrokorra
    {
        private int id;
        private String izena;
        private String abizena;
        private String postua;
        private String helbidea;
        private String email;
        private int telefonoa;
        private String pasahitza;

        public langileOrokorra(int id, String izena, String abizena, String postua, String helbidea, String email, int telefonoa, String pasahitza)
        {
            this.id = id;
            this.izena = izena;
            this.abizena = abizena;
            this.postua = postua;
            this.helbidea = helbidea;
            this.email = email;
            this.telefonoa = telefonoa;
            this.pasahitza = pasahitza;
        }


        public static DataTable zitak_ikusi()
        {
            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";

            string query = "SELECT * FROM zitak";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);

                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las citas: " + ex.Message);
                    return null;
                }
            }
        }

        public static void zita_eguneratu(string id)
        {
            string connectionString = "Server=192.168.115.167;Database=hirugarrenerronka;Uid=erronka3;Pwd=1MG32025;";
            QuestPDF.Settings.License = LicenseType.Community;

            if (!int.TryParse(id, out int citaId))
            {
                MessageBox.Show("Sartu baliozko ID bat.");
                return;
            }

            string rutaCarpeta = @"C:\pdfs\";
            if (!Directory.Exists(rutaCarpeta)) Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"Factura_{citaId}.pdf");

            string garbitzeMotaTexto = "Garbiketa zerbitzua";
            string prezioaTexto = "0€";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT garbitze_mota, prezioa FROM zitak WHERE id = @id";
                    using (MySqlCommand cmdSelect = new MySqlCommand(selectQuery, conn))
                    {
                        cmdSelect.Parameters.AddWithValue("@id", citaId);
                        using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                garbitzeMotaTexto = reader["garbitze_mota"].ToString();
                                prezioaTexto = reader["prezioa"].ToString() + "€";
                            }
                        }

                        string query = "UPDATE zitak SET egoera = 'Garbituta', pdf = @ruta WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ruta", rutaCompleta);
                            cmd.Parameters.AddWithValue("@id", citaId);

                            int filas = cmd.ExecuteNonQuery();

                            if (filas > 0)
                            {
                                GenerarPdfConQuest(rutaCompleta, garbitzeMotaTexto, prezioaTexto, id);
                                MessageBox.Show("Egoera aldatuta eta PDFa sortuta.");
                            }
                            else
                            {
                                MessageBox.Show("Ez da aurkitu ID hori duen zitarik.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea: " + ex.Message);
                }
                try
                {
                    using (var client = new FtpClient("192.168.115.167", "erronka3", "1MG32025"))
                    {
                        client.Config.EncryptionMode = FtpEncryptionMode.Explicit;
                        client.Config.ValidateAnyCertificate = true;

                        client.Connect();

                        using (var fileStream = new FileStream(@"C:\pdfs\Factura_" + id + ".pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            client.UploadStream(fileStream, $"/Factura_{id}.pdf");
                        }

                        client.Disconnect();
                    }
                    MessageBox.Show("Faktura behar bezala gorde da FTP zerbitzarian.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea FTP-ra igotzean: " + ex.Message);
                }

                string ftpUrl = $"ftp://192.168.115.167/C:/pdfs/Factura_{id}.pdf";
                string user = "erronka3";
                string pass = "1MG32025";
                string localFile = @$"C:\pdfs\Factura_{id}.pdf";

                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(user, pass);

                    byte[] fileContents = File.ReadAllBytes(localFile);
                    request.ContentLength = fileContents.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        Console.WriteLine($"Igoera izugarria: {response.StatusDescription}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errorea: " + ex.Message);
                }
            }
        }

        public static void GenerarPdfConQuest(string ruta, string mota, string prezioa, string idTexto)
        {
            string rutaLogo = @"C:\Resources\logoA1A_CAR_WASH.jpeg";
            try
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1, Unit.Centimetre);
                        page.Size(PageSizes.A4);

                        page.Header().Row(row =>
                        {
                            row.RelativeItem().Text("Garbikuntzaren txostena").FontSize(25).SemiBold().FontColor(Colors.Blue.Medium);
                            row.RelativeItem().Image(rutaLogo).FitArea();
                        });

                        page.Content().PaddingVertical(20).Column(col =>
                        {
                            col.Spacing(3);
                            col.Item().Text("Gure enpresari buruz:").Bold();
                            col.Item().Text("Izena: A1A CAR WASH");
                            col.Item().Text("Sortzaileak: Ander Criado, Manex Olano eta Odei Otxoaerrarte");
                            col.Item().Text("Helbidea: Kale Nagusia, 123, 48000 Bilbao");

                            col.Item().PaddingTop(10).LineHorizontal(1);
                            col.Spacing(5);
                            col.Item().Text($"Zitaren ID-a: {idTexto}").Bold();
                            col.Item().Text("Egoera: Garbituta (Bukatuta)").FontColor(Colors.Green.Medium);
                            col.Item().Text($"{DateTime.Now:dd/MM/yyyy HH:mm}");

                            col.Item().PaddingTop(10).LineHorizontal(1);

                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(c =>
                                {
                                    c.RelativeColumn();
                                    c.ConstantColumn(80);
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Text("Deskribapena");
                                    h.Cell().AlignRight().Text("Prezioa");
                                });

                                table.Cell().Text(mota);
                                table.Cell().AlignRight().Text(prezioa);
                            });
                        });
                    });
                }).GeneratePdf(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea diseinuan: " + ex.Message);
            }
        }

    }
}