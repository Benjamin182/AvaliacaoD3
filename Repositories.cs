using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using AvaliacaoD3;


namespace AvaliacaoD3
{

    public class Repositories : IUser
    {
     
        private readonly string stringConexao = "Data Source=labsoft.pcs.usp.br;User ID=usuario_15;Password= 2274781265; Database = db_15;";

        public void Create(User newProduct)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Tabela (Id, Name, Email, Senha) VALUES (@Id, @Name, @Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", newProduct.IdUser);
                    cmd.Parameters.AddWithValue("@Name", newProduct.Name);
                    cmd.Parameters.AddWithValue("@Email", newProduct.Email);
                    cmd.Parameters.AddWithValue("@Senha", newProduct.Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string idProduct)
        {
            throw new NotImplementedException();
        }

        public List<User> ReadAll()
        {
            List<User> listProducts = new();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM Tabela";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        User user = new()
                        {
                            IdUser = rdr["Id"].ToString(),
                            Name = rdr[1].ToString(),
                            Email = rdr[2].ToString(),
                            Senha = Convert.ToString(rdr[3])
                        };

                        listProducts.Add(user);
                    }
                }
            }

            return listProducts;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}