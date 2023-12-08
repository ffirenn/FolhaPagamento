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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace FormLogin
{
    public partial class FormMenu : Form
    {
        public FormMenu(string usuario)
        {

            InitializeComponent();
            
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OE6BCJ2\SQLPIM;Initial Catalog=SistemaRH;Integrated Security=True");
            
            try
            {
                // Pegar os valores de cada coluna no banco de dados
                String GetNome = "select NomeFunc from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetEmail = "select Email from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetDep = "select NomeDep from Departamento as t1 inner join LoginSistema as t2 on t1.ID_Departamento = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetCargo = "select Cargo from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String ID_Funcionario = "SELECT t1.ID_Funcionario FROM Funcionario as t1 JOIN LoginSistema as t2 ON t1.ID_LoginSistema = t2.ID_LoginSistema WHERE t2.Usuario = '" + usuario + "'";
            
                SqlCommand commandID_Funcionario = new SqlCommand(ID_Funcionario, conn);
                conn.Open();
                int funcionario = (int)commandID_Funcionario.ExecuteScalar();
                // Comandos
                SqlCommand commandNome = new SqlCommand(GetNome, conn);
                SqlCommand commandEmail = new SqlCommand(GetEmail, conn);
                SqlCommand commandDep = new SqlCommand(GetDep, conn);
                SqlCommand commandCargo = new SqlCommand(GetCargo, conn);
                SqlCommand commandAno = new SqlCommand("select top 1 ID_FolhaPagamento, AnoRef from FolhaPagamento", conn);
                SqlCommand commandMes = new SqlCommand("select t1.ID_FolhaPagamento, t1.MesRef from FolhaPagamento as t1 join Funcionario as t2 on t1.ID_Funcionario = t2.ID_Funcionario where t2.ID_LoginSistema ='" + funcionario + "'", conn);
                
                
                
                string nome = (string)commandNome.ExecuteScalar();
                string email = (string)commandEmail.ExecuteScalar();
                string dep = (string)commandDep.ExecuteScalar();
                string cargo = (string)commandCargo.ExecuteScalar();

                // Muda o texto 
                this.label_user.Text = usuario;
                this.txt_nome.Text = nome;
                this.txt_email.Text = email;
                this.txt_dep.Text = dep;
                this.txt_cargo.Text = cargo;
              

                // Preencher Valor da ComboBox_Ano
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = commandAno;
                DataTable table1 = new DataTable();
                da.Fill(table1);
                DataRow dr1 = table1.NewRow();
                dr1[1] = "";
                table1.Rows.InsertAt(dr1, 0);
                comboBox_Ano.DataSource = table1;
                comboBox_Ano.DisplayMember = "AnoRef";
                comboBox_Ano.ValueMember = "ID_FolhaPagamento";



                // Preencher Valor da ComboBox_Mes
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = commandMes;
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                DataRow dr2 = table2.NewRow();
                dr2[1] = "";
                table2.Rows.InsertAt(dr2, 0);
                comboBox_Mes.DataSource = table2;
                comboBox_Mes.DisplayMember = "MesRef";
                comboBox_Mes.ValueMember = "ID_FolhaPagamento";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
            
            conn.Close();
         

        }

        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            int ohretro = 0;
           
         

            if (comboBox_Ano.Text == "")
            {
                ohretro = 1;
            }
            if (comboBox_Mes.Text == "")
            {
                ohretro = 1;
            }
            if (ohretro == 0)
            {
                String mesAno = "" + comboBox_Mes.Text + "/" + comboBox_Ano.Text;

                String usuario = label_user.Text;
                Form_Folha form2 = new Form_Folha(usuario, mesAno);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mês/Ano Obrigatório!");
            }
        }
    }
}
