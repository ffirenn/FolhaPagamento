using System.ComponentModel;

namespace FormLogin
{
    partial class FormMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_visualizar = new System.Windows.Forms.Button();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_nome = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_dep = new System.Windows.Forms.TextBox();
            this.label_dep = new System.Windows.Forms.Label();
            this.picturebox_menu = new System.Windows.Forms.PictureBox();
            this.txt_cargo = new System.Windows.Forms.TextBox();
            this.label_cargo = new System.Windows.Forms.Label();
            this.label_AnoRef = new System.Windows.Forms.Label();
            this.label_MesRef = new System.Windows.Forms.Label();
            this.comboBox_Mes = new System.Windows.Forms.ComboBox();
            this.label_user = new System.Windows.Forms.Label();
            this.sistemaRHDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_Ano = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaRHDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_visualizar
            // 
            this.btn_visualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_visualizar.Location = new System.Drawing.Point(129, 336);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Size = new System.Drawing.Size(130, 31);
            this.btn_visualizar.TabIndex = 0;
            this.btn_visualizar.Text = "Visualizar";
            this.btn_visualizar.UseVisualStyleBackColor = true;
            this.btn_visualizar.Click += new System.EventHandler(this.btn_visualizar_Click);
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(129, 57);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.ReadOnly = true;
            this.txt_nome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_nome.ShortcutsEnabled = false;
            this.txt_nome.Size = new System.Drawing.Size(306, 20);
            this.txt_nome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Demonstrativo de Pagamento";
            // 
            // label_nome
            // 
            this.label_nome.AutoSize = true;
            this.label_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nome.Location = new System.Drawing.Point(66, 57);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(55, 20);
            this.label_nome.TabIndex = 3;
            this.label_nome.Text = "Nome:";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(66, 85);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(57, 20);
            this.label_email.TabIndex = 4;
            this.label_email.Text = "E-mail:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(129, 85);
            this.txt_email.Name = "txt_email";
            this.txt_email.ReadOnly = true;
            this.txt_email.Size = new System.Drawing.Size(306, 20);
            this.txt_email.TabIndex = 5;
            // 
            // txt_dep
            // 
            this.txt_dep.Location = new System.Drawing.Point(129, 143);
            this.txt_dep.Name = "txt_dep";
            this.txt_dep.ReadOnly = true;
            this.txt_dep.Size = new System.Drawing.Size(306, 20);
            this.txt_dep.TabIndex = 7;
            // 
            // label_dep
            // 
            this.label_dep.AutoSize = true;
            this.label_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dep.Location = new System.Drawing.Point(12, 143);
            this.label_dep.Name = "label_dep";
            this.label_dep.Size = new System.Drawing.Size(116, 20);
            this.label_dep.TabIndex = 6;
            this.label_dep.Text = "Departamento:";
            // 
            // picturebox_menu
            // 
            this.picturebox_menu.Image = global::FormLogin.Properties.Resources.WhatsApp_Image_2023_10_22_at_14_09_12;
            this.picturebox_menu.Location = new System.Drawing.Point(459, 59);
            this.picturebox_menu.Name = "picturebox_menu";
            this.picturebox_menu.Size = new System.Drawing.Size(269, 308);
            this.picturebox_menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_menu.TabIndex = 8;
            this.picturebox_menu.TabStop = false;
            // 
            // txt_cargo
            // 
            this.txt_cargo.Location = new System.Drawing.Point(129, 117);
            this.txt_cargo.Name = "txt_cargo";
            this.txt_cargo.ReadOnly = true;
            this.txt_cargo.Size = new System.Drawing.Size(306, 20);
            this.txt_cargo.TabIndex = 10;
            // 
            // label_cargo
            // 
            this.label_cargo.AutoSize = true;
            this.label_cargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cargo.Location = new System.Drawing.Point(65, 115);
            this.label_cargo.Name = "label_cargo";
            this.label_cargo.Size = new System.Drawing.Size(56, 20);
            this.label_cargo.TabIndex = 9;
            this.label_cargo.Text = "Cargo:";
            // 
            // label_AnoRef
            // 
            this.label_AnoRef.AutoSize = true;
            this.label_AnoRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AnoRef.Location = new System.Drawing.Point(47, 181);
            this.label_AnoRef.Name = "label_AnoRef";
            this.label_AnoRef.Size = new System.Drawing.Size(76, 20);
            this.label_AnoRef.TabIndex = 11;
            this.label_AnoRef.Text = "Ano Ref.:";
            // 
            // label_MesRef
            // 
            this.label_MesRef.AutoSize = true;
            this.label_MesRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MesRef.Location = new System.Drawing.Point(46, 205);
            this.label_MesRef.Name = "label_MesRef";
            this.label_MesRef.Size = new System.Drawing.Size(77, 20);
            this.label_MesRef.TabIndex = 12;
            this.label_MesRef.Text = "Mês Ref.:";
            // 
            // comboBox_Mes
            // 
            this.comboBox_Mes.FormattingEnabled = true;
            this.comboBox_Mes.Location = new System.Drawing.Point(129, 207);
            this.comboBox_Mes.Name = "comboBox_Mes";
            this.comboBox_Mes.Size = new System.Drawing.Size(130, 21);
            this.comboBox_Mes.TabIndex = 14;
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(693, 9);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(35, 13);
            this.label_user.TabIndex = 15;
            this.label_user.Text = "label2";
            // 
            // comboBox_Ano
            // 
            this.comboBox_Ano.FormattingEnabled = true;
            this.comboBox_Ano.Location = new System.Drawing.Point(129, 183);
            this.comboBox_Ano.Name = "comboBox_Ano";
            this.comboBox_Ano.Size = new System.Drawing.Size(130, 21);
            this.comboBox_Ano.TabIndex = 17;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 391);
            this.Controls.Add(this.comboBox_Ano);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.comboBox_Mes);
            this.Controls.Add(this.label_MesRef);
            this.Controls.Add(this.label_AnoRef);
            this.Controls.Add(this.txt_cargo);
            this.Controls.Add(this.label_cargo);
            this.Controls.Add(this.picturebox_menu);
            this.Controls.Add(this.txt_dep);
            this.Controls.Add(this.label_dep);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_nome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.btn_visualizar);
            this.Name = "FormMenu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaRHDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_visualizar;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_dep;
        private System.Windows.Forms.Label label_dep;
        private System.Windows.Forms.PictureBox picturebox_menu;
        private System.Windows.Forms.TextBox txt_cargo;
        private System.Windows.Forms.Label label_cargo;
        private System.Windows.Forms.Label label_AnoRef;
        private System.Windows.Forms.Label label_MesRef;
        private System.Windows.Forms.ComboBox comboBox_Mes;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.BindingSource sistemaRHDataSetBindingSource;
        private ISupportInitialize sistemaRHDataSet;
        private System.Windows.Forms.ComboBox comboBox_Ano;
    }
}

