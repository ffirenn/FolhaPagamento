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
namespace FormLogin
{
    public partial class FormMenu : Form
    {
        public FormMenu(string texto)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OE6BCJ2\SQLPIM;Initial Catalog=SistemaRH;Integrated Security=True");


            String GetFunc = "select NomeFunc from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t1.Usuario = " + texto;
            SqlCommand cmd = new SqlCommand(GetFunc, conn);
            object result = cmd.ExecuteScalar();
            Console.WriteLine(result);
            //this.txt_nome.Text = result == null ? "0" : result.ToString();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
