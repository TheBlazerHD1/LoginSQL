using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginSQL
{
    internal class clsConexion
    {
        public string stringConecte = "Server=REYANLDO\\SQLEXPRESS;Database=Usuarios;Integrated Security=True;";
        public int[] iD { get; set; }
        public string[] Usuario { get; set; }
        public string[] Password { get; set; }
        public string[] Direccion { get; set; }

        public void Conexion()
        {

            using (SqlConnection conexion = new SqlConnection(stringConecte))
            {
                try
                {
                    conexion.Open();
                    MessageBox.Show("Conexion establecida");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Conexion no establecida" + ex.Message);
                }
            }
        }
        public void Datos()
        {
            string query = "select * from Usuarios2";
            using (SqlConnection Conect = new SqlConnection(stringConecte))
            {
                int rowCount = 0;
                try
                {
                    Conect.Open();
                    using (SqlCommand Comando = new SqlCommand(query, Conect))
                    {
                        using (SqlDataReader reader = Comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    rowCount++;
                                }
                            }
                        }
                    }

                    iD = new int[rowCount];
                    Usuario = new string[rowCount];
                    Password = new string[rowCount];
                    Direccion = new string[rowCount];

                    using (SqlCommand comando = new SqlCommand(query, Conect))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                iD[i] = reader.GetInt32(0);
                                Usuario[i] = reader.GetString(1);
                                Direccion[i] = reader.GetString(2);
                                Password[i] = reader.GetString(3);
                                i++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Peto la carga de datos" + ex.Message);

                }
            }
        }
        public DataTable DatosDT(DataTable dt)
        {
            string query = "select * from Usuarios2";
            using (SqlConnection Conect = new SqlConnection(stringConecte))
            {
                int rowCount = 0;
                try
                {
                    Conect.Open();
                    using (SqlCommand Comando = new SqlCommand(query, Conect))
                    {
                        using (SqlDataReader reader = Comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    rowCount++;
                                }
                            }
                        }
                    }

                    iD = new int[rowCount];
                    Usuario = new string[rowCount];
                    Password = new string[rowCount];
                    Direccion = new string[rowCount];

                    using (SqlCommand comando = new SqlCommand(query, Conect))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                iD[i] = reader.GetInt32(0);
                                Usuario[i] = reader.GetString(1);
                                Direccion[i] = reader.GetString(2);
                                Password[i] = reader.GetString(3);
                                i++;
                            }
                        }
                    }

                    dt.Columns.Clear();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("Nombre", typeof(string));
                    dt.Columns.Add("Direccion", typeof(string));
                    dt.Columns.Add("Contraseña", typeof(string));


                    for (int i = 0; i < rowCount; i++)
                    {
                        dt.Rows.Add(iD[i], Usuario[i], Direccion[i], Password[i]);
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Peto la carga de datos" + ex.Message);
                    return dt;

                }
            }
        }
        public void Agregar(string usuario, string direccion, string pass)
        {
            string query = "INSERT INTO Usuarios2 (Usuario, Direccion, Password) VALUES (@usuario,@direccion,@password);";

            using (SqlConnection conexion = new SqlConnection(stringConecte))
            {
                try
                {
                    conexion.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Usuarios2 WHERE Usuario = @Usuario";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conexion))
                    {
                        checkCommand.Parameters.AddWithValue("@Usuario", usuario);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("El usuario ya existe.");
                        }
                        else
                        {
                            using (SqlCommand comando = new SqlCommand(query, conexion))
                            {
                                comando.Parameters.AddWithValue("@usuario", usuario);
                                comando.Parameters.AddWithValue("@direccion", direccion);
                                comando.Parameters.AddWithValue("@password", pass);

                                int rows = comando.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    MessageBox.Show("Usuario Agregado!");
                                }
                                else
                                {
                                    MessageBox.Show("Usuario No Agregado");

                                }
                            }
                        }
                        conexion.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
