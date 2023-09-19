using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_CRUD
{
    public partial class frmCadastroLivros : Form
    {
        private BancoDados bancoDados;
        private bool novo;
        
        public frmCadastroLivros()
        {
            InitializeComponent();
        }

        private void FrmCadastroLivros_Load(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = false;

            txtBusca.Enabled = true;
            btnBuscar.Enabled= true;

            txtCodigo.Enabled = false;
            txtTitulo.Enabled = false;  
            txtAutor.Enabled = false;          
            txtEditor.Enabled = false;
            txtGenero.Enabled = false;
            bancoDados = new BancoDados();

            DataSet dataSet = bancoDados.ListarTodos();
            if (dataSet != null)
            {
                tbLivros.DataSource = dataSet.Tables[0];
            }
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnAdicionar.Enabled=false;            
            btnExcluir.Enabled=false;

            txtBusca.Enabled = false;
            btnBuscar.Enabled = false;

            txtCodigo.Enabled=false;
            txtTitulo.Enabled=true;
            txtAutor.Enabled=true;
            txtEditor.Enabled=true;
            txtGenero.Enabled = true;

            txtTitulo.Focus();
            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(novo)
            {
                string sql = "INSERT INTO livros(titulo,autor,editor,genero) " +
                    "VALUES ('" + txtTitulo.Text + "', '" + txtAutor.Text + "', " +
                    "'" + txtEditor.Text + "', '" + txtGenero.Text + "')";

                bool sucesso = bancoDados.ExecutarQuery(sql);

                if (sucesso) 
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }                
            }
            else
            {
                string sql = "UPDATE livros SET titulo = '" + txtTitulo.Text + "', autor = '" + txtAutor.Text + "', " +
                    "editor = '" + txtEditor.Text + "', genero = '" + txtGenero.Text + "'" +
                    " WHERE codigo = " + txtCodigo.Text + "";

                bool sucesso = bancoDados.ExecutarQuery(sql);

                if (sucesso)
                {
                    MessageBox.Show("Atualizado com sucesso!");
                }
            }

            btnSalvar.Enabled = false;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = false;

            txtBusca.Enabled = true;
            btnBuscar.Enabled = true;

            txtCodigo.Enabled = false;
            txtTitulo.Enabled = false;
            txtAutor.Enabled = false;
            txtEditor.Enabled = false;
            txtGenero.Enabled = false;

            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditor.Text = "";
            txtGenero.Text = "";
            txtBusca.Text = "";

            RecarregarTabela();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM livros WHERE codigo = " + txtCodigo.Text + "";
            bool sucesso = bancoDados.ExecutarQuery(sql);

            if (sucesso)
            {
                MessageBox.Show("Excluído com sucesso!");
            }

            btnSalvar.Enabled = false;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = false;

            txtBusca.Enabled = true;
            btnBuscar.Enabled = true;

            txtCodigo.Enabled = false;
            txtTitulo.Enabled = false;
            txtAutor.Enabled = false;
            txtEditor.Enabled = false;
            txtGenero.Enabled = false;

            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditor.Text = "";
            txtGenero.Text = "";
            txtBusca.Text = "";
            RecarregarTabela();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM livros WHERE codigo = " + txtBusca.Text + "";

            Livro livro = bancoDados.ExecutarConsulta(sql);

            if (livro != null)
            {
                btnSalvar.Enabled = true;
                btnAdicionar.Enabled = false;
                btnExcluir.Enabled = true;

                txtBusca.Enabled = false;
                btnBuscar.Enabled = false;
                
                txtCodigo.Enabled = false;
                txtTitulo.Enabled = true;
                txtAutor.Enabled = true;
                txtEditor.Enabled = true;
                txtGenero.Enabled = true;
                txtTitulo.Focus();

                txtCodigo.Text = livro.GetCodigo().ToString();
                txtTitulo.Text = livro.GetTitulo();
                txtAutor.Text = livro.GetAutor();
                txtEditor.Text = livro.GetEditor();
                txtGenero.Text = livro.GetGenero();
                novo = false;
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }

            txtBusca.Text = "";
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            RecarregarTabela();
        }

        private void RecarregarTabela()
        {
            DataSet dataSet = bancoDados.ListarTodos();
            if (dataSet != null)
            {
                tbLivros.DataSource = dataSet.Tables[0];
            }
        }
    }
}
