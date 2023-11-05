using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;


namespace FormLogin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OE6BCJ2\SQLPIM;Initial Catalog=SistemaRH;Integrated Security=True");
               
        private void button1_Click(object sender, EventArgs e)
        {
            String usuario, senha;

            usuario = txt_usuario.Text;
            senha = txt_senha.Text;

            try
            {
                String querry = "SELECT * FROM LoginSistema WHERE Usuario = '" + txt_usuario.Text + "' AND Senha = '" + txt_senha.Text + "'";
                //String GetFunc = "select NomeFunc from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t1.Usuario = "+ txt_usuario.Text;
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0) 
                {

                    usuario = txt_usuario.Text;
                    senha = txt_senha.Text;

                    FormMenu form1 = new FormMenu(usuario);
                    form1.Show();
                    this.Hide();
                }

                else

                {
                    MessageBox.Show("Login Inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_usuario.Clear();
                    txt_senha.Clear();

                    txt_usuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.Message");
            }
            finally
            {
                conn.Close();
            }

        }

    }
}