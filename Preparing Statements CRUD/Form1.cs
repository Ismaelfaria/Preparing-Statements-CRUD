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

        private void label4_Click(object sender, EventArgs e)
        {

        }
                                                                                                                                                                                                                                                                                                                            
        private void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var commSelect = new MySqlCommand();
                commSelect.Connection = conn;

                commSelect.CommandText = "SELECT * FROM contato WHERE nome LIKE @q OR email LIKE @q ";

                commSelect.Parameters.AddWithValue("@q", "%" + txtBuscar + "%");

                MySqlDataReader reader = commSelect.ExecuteReader();

                listContatos.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                    };

                    var linha_listView = new ListViewItem(row);

                    listContatos.Items.Add(linha_listView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
