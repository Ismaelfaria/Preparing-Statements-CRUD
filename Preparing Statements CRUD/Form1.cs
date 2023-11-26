using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;



namespace Preparing_Statements_CRUD
{
    public partial class Form1 : Form
    {

        MySqlConnection conn;
        string sql = "datasource=localhost;username=root;password=123456;database=db_agenda";
        public Form1()
        {
            InitializeComponent();
        }

        private void Salvar_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtNome.Text) &&
                !String.IsNullOrEmpty(txtNome.Text) &&
                !String.IsNullOrEmpty(txtNome.Text))
            {
                try
                {
                    conn = new MySqlConnection(sql);
                    conn.Open();

                    var comInsert = new MySqlCommand();

                    comInsert.Connection = conn;

                    comInsert.CommandText = "INSERT INTO contato (nome, email, telefone) "+
                        "VALUES (@nome, @email, @telefone) ";

                    comInsert.Parameters.AddWithValue("@nome", txtNome.Text);
                    comInsert.Parameters.AddWithValue("@email", txtEmail.Text);
                    comInsert.Parameters.AddWithValue("@telefone", txtTelefone.Text);

                    comInsert.Prepare();

                    comInsert.ExecuteNonQuery();

                    MessageBox.Show("Deu tudo certo, contato adicionado!!");
                }
                catch (MySqlException ex)
                {
                    ExceptionText.MetodoComExcecao(ex);
                }
                catch (Exception ex)
                {
                    ExceptionText.MetodoComExcecao(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Verifique se preencheu todos os campos.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
