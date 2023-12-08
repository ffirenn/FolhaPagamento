using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using iText.Kernel.Geom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using Image = iText.Layout.Element.Image;
using iText.Layout.Borders;

namespace FormLogin
{
    public partial class Form_Folha : Form
    {
        public Form_Folha(String usuario, String mesAno)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OE6BCJ2\SQLPIM;Initial Catalog=SistemaRH;Integrated Security=True");
            conn.Open();

            try
            {
                // Pegar os valores de cada coluna no banco de dados
                String GetID = "select ID_Funcionario from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetNome = "select NomeFunc from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetCargo = "select Cargo from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetDep = "select NomeDep from Departamento as t1 inner join LoginSistema as t2 on t1.ID_Departamento = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetSalarioBruto = "select Salario from Funcionario as t1 inner join LoginSistema as t2 on t1.ID_Funcionario = t2.ID_LoginSistema where t2.Usuario ='" + usuario + "'";
                String GetValeTransporte = "select ValorBenef from Beneficio where ID_Beneficio = 1";
                String GetImpostoRenda = "select ValorDed from Deducoes where ID_Deducoes = 2";
                String GetINSS = "select ValorDed from Deducoes where ID_Deducoes = 1";
                

                //Comandos
                SqlCommand commandID = new SqlCommand(GetID, conn);
                SqlCommand commandNome = new SqlCommand(GetNome, conn);
                SqlCommand commandDep = new SqlCommand(GetDep, conn);
                SqlCommand commandCargo = new SqlCommand(GetCargo, conn);
                SqlCommand commandSalarioBruto= new SqlCommand(GetSalarioBruto, conn);
                SqlCommand commandValeTransporte = new SqlCommand(GetValeTransporte, conn);
                SqlCommand commandImpostoRenda = new SqlCommand(GetImpostoRenda, conn);
                SqlCommand commandINSS = new SqlCommand(GetINSS, conn);




                string Nome = (string)commandNome.ExecuteScalar();
                string Dep = (string)commandDep.ExecuteScalar();
                string Cargo = (string)commandCargo.ExecuteScalar();
                int ID = (int)commandID.ExecuteScalar();
                decimal SalarioBruto = (decimal)commandSalarioBruto.ExecuteScalar();
                decimal ValeTransporte = (decimal) commandValeTransporte.ExecuteScalar();
                decimal ImpostoRenda = (decimal)commandImpostoRenda.ExecuteScalar();
                decimal INSS = (decimal)commandINSS.ExecuteScalar();



                // Muda o texto 
                string get_id = "" + ID;
                this.txt_Nome2.Text = Nome;
                this.txt_Empresa.Text = "HIPER MTECH TECHNOLOGY";
                this.txt_ID.Text = get_id;
                this.txt_Cargo2.Text = Cargo;
                this.txt_Dep2.Text = Dep;
                this.txt_SalarioBruto.Text = "" + SalarioBruto;
                this.txt_TotalProventos.Text = "" + (SalarioBruto + ValeTransporte);
                this.txt_ValeTransporte.Text = "" + ValeTransporte;
                this.txt_ImpostoRenda.Text = (SalarioBruto * ImpostoRenda).ToString("0.00");
                this.txt_INSS.Text = (SalarioBruto * INSS).ToString("0.00");
                this.txt_TotalDesconto.Text = "" + (SalarioBruto * INSS + SalarioBruto * ImpostoRenda).ToString("0.00");
                this.txt_SalarioLiquido.Text = "" + (SalarioBruto - (SalarioBruto * INSS + SalarioBruto * ImpostoRenda)).ToString("0.00");
                this.txt_Periodo.Text = mesAno;
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            GerarPDF();
        }


        private void GerarPDF()
        {
            var arquivo = @"C:\dados\FolhaPagamento.pdf";

            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);

                var document = new iText.Layout.Document(pdfDocument, iText.Kernel.Geom.PageSize.A4);

                document.Add(new Paragraph("Hiper MTech Technology\n\n").SetFirstLineIndent(112).SetFontSize(15));

                var logo = @"C:\dados\logo_white.jpeg";

                Image img = new Image(iText.IO.Image.ImageDataFactory.Create(logo));
                img.ScaleAbsolute(96, 96);
                img.SetFixedPosition(50f, 750f);
                document.Add(img);  

                //cabeçalho
                var TimesNewRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                var p1 = new Paragraph();
                p1.SetFont(TimesNewRoman);
                p1.SetFontSize(30);
                p1.SetTextAlignment(TextAlignment.CENTER);
                p1.SetFontColor(ColorConstants.WHITE);
                p1.SetBackgroundColor(ColorConstants.DARK_GRAY);
                p1.Add("Demonstrativo de Pagamento");
                document.Add(p1);

                //criação tabela 1
                float[] columnWidths = { 30, 8, 20, 15, 15 };
                Table tabela = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                tabela.AddHeaderCell(new Paragraph("NOME")
                    .SetBackgroundColor(ColorConstants.GRAY)
                    .SetFontSize(13)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(this.txt_Nome2.Text)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela.AddHeaderCell(new Paragraph("ID")
                    .SetBackgroundColor(ColorConstants.GRAY)
                    .SetFontSize(13)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(this.txt_ID.Text)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela.AddHeaderCell(new Paragraph("DEPARTAMENTO")
                    .SetBackgroundColor(ColorConstants.GRAY)
                    .SetFontSize(13)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(this.txt_Dep2.Text)
                    .SetFontSize(12).SetTextAlignment(TextAlignment.CENTER));

                tabela.AddHeaderCell(new Paragraph("CARGO")
                    .SetBackgroundColor(ColorConstants.GRAY)
                    .SetFontSize(13)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(this.txt_Cargo2.Text)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela.AddHeaderCell(new Paragraph("PERÍODO")
                    .SetBackgroundColor(ColorConstants.GRAY)
                    .SetFontSize(13)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(this.txt_Periodo.Text)
                    .SetFontSize(12).SetTextAlignment(TextAlignment.CENTER));

                

                tabela.SetSkipFirstHeader(false);
                document.Add(tabela);

                // tabela 2
                float[] columnWidths2 = { 40, 40, 40, 40 };
                Table tabela2 = new Table(UnitValue
                    .CreatePercentArray(columnWidths2))
                    .UseAllAvailableWidth();

                tabela2.AddHeaderCell(new Cell(1, 4)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph("\n RECIBO \n").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(18)));

                tabela2.AddCell(new Paragraph("PROVENTOS").SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("NUM").SetBold().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("VALOR (R$)").SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("Salário Bruto"))
                    .AddCell(new Paragraph())
                    .AddCell(new Paragraph())
                    .AddCell(new Paragraph(txt_SalarioBruto.Text)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("Vale Transporte"))
                    .AddCell(new Paragraph())
                    .AddCell(new Paragraph()) 
                    .AddCell(new Paragraph(txt_ValeTransporte.Text)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("TOTAL PROVENTOS").SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(txt_TotalProventos.Text).SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("\n"))
                     .AddCell(new Paragraph())
                     .AddCell(new Paragraph())
                     .AddCell(new Paragraph());

                tabela2.AddCell(new Paragraph("DESCONTOS").SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .SetMargins(-2, -2, -2, -2);
                
                tabela2.AddCell(new Paragraph("Imposto de Renda"))
                   .AddCell(new Paragraph())
                   .AddCell(new Paragraph("14")
                   .SetTextAlignment(TextAlignment.CENTER))
                   .AddCell(new Paragraph(txt_ImpostoRenda.Text)
                   .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("INSS"))
                   .AddCell(new Paragraph())
                   .AddCell(new Paragraph("5")
                   .SetTextAlignment(TextAlignment.CENTER))
                   .AddCell(new Paragraph(txt_INSS.Text)
                   .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("TOTAL DESCONTOS").SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(txt_TotalDesconto.Text).SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER));

                tabela2.AddCell(new Paragraph("\n"))
                    .AddCell(new Paragraph())
                    .AddCell(new Paragraph())
                    .AddCell(new Paragraph());
                    
                   

                tabela2.AddCell(new Paragraph("TOTAL LIQUÍDO").SetBold()
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph("STRING").SetFontColor(ColorConstants.LIGHT_GRAY).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetMargins(-2, -2, -2, -2))
                    .AddCell(new Paragraph(txt_SalarioLiquido.Text).SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetMargins(-2, -2, -2, -2)
                    .SetPaddingLeft(2)
                    .SetTextAlignment(TextAlignment.CENTER)
                    );
                

                document.Add(tabela2);

                document.Close();

                pdfDocument.Close();

                MessageBox.Show("Arquivo PDF gerado em" + arquivo);
            }

        }
    }
}
