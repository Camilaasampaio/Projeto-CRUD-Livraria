using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_CRUD
{
    internal class BancoDados
    {
        public bool ExecutarQuery(string query)
        {
            string stringConexao = @"Server=.\sqlexpress;Database=db_livraria;Trusted_Connection=True;";
            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand comando = new SqlCommand(query, conexao);
            comando.CommandType = CommandType.Text;
            conexao.Open();

            try
            {
                comando.ExecuteNonQuery();
                conexao.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.ToString());
                conexao.Close();
                return false;
            }
        }

        public Livro ExecutarConsulta(string query)
        {
            string stringConexao = @"Server=.\sqlexpress;Database=db_livraria;Trusted_Connection=True;";
            SqlConnection conexao = new SqlConnection(stringConexao);
            SqlCommand comando = new SqlCommand(query, conexao);
            comando.CommandType = CommandType.Text;
            conexao.Open();

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                Livro livro;
                
                if (reader.Read())
                {
                    livro = new Livro(reader);
                } else
                {
                    livro = null;

                }
                conexao.Close();
                return livro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.ToString());
                conexao.Close();
                return null;
            }
        }

        public DataSet ListarTodos()
        {
            string sql = "SELECT * FROM livros";
            string stringConexao = @"Server=.\sqlexpress;Database=db_livraria;Trusted_Connection=True;";

            SqlConnection conexao = new SqlConnection(stringConexao);
            DataSet dataSet = new DataSet();
            conexao.Open();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);
                adapter.Fill(dataSet);
                conexao.Close();
                return dataSet;
            }
            catch (Exception ex)
            {
                conexao.Close();
                return null;
            }
        }
    }
}
