using System.Data.SqlClient;

namespace Projeto_CRUD
{
    internal class Livro
    {
        private int codigo;
        private string titulo;
        private string autor;
        private string editor;
        private string genero;

        public Livro(SqlDataReader reader)
        {
            codigo = (int)reader[0];
            titulo = reader[1].ToString();
            autor = reader[2].ToString();
            editor = reader[3].ToString();
            genero = reader[4].ToString();
        }

        public int GetCodigo()
        {
            return codigo;
        }

        public void SetCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public string GetTitulo()
        {
            return titulo;
        }

        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string GetAutor()
        {
            return autor;
        }

        public void SetAutor(string autor) 
        {
            this.autor = autor;    
        }

        public string GetEditor()
        {
            return editor;
        }

        public void SetEditor(string editor)
        {
            this.editor = editor;
        }

        public string GetGenero()
        {
            return genero;
        }

        public void SetGenero(string genero)
        {
            this.genero = genero;
        }
    }
}
