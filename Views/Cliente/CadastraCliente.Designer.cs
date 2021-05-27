using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
namespace Views
{
    public partial class CadastraCliente : FormBase
    {
        Label lblCadastraCliente;
        Label lblNome;
        RichTextBox rtxtNome;
        Label lblDtNasc;
        MaskedTextBox txtDtNasc;
        Label lblCpf;
        MaskedTextBox txtCpf;
        Label lblDiasDev;
        NumericUpDown numDiasDev;
        Button btnConfirma;
        Button btnCancela;

        public void InitializeComponent(Form parent, bool isUpdate){

            lblCadastraCliente = new Label();
            lblCadastraCliente.Location = new Point(100,10);
            lblCadastraCliente.Text = "Cadastra Cliente";
            this.Controls.Add(lblCadastraCliente);

            if (isUpdate){
                this.Load+=new EventHandler(this.LoadForm);
            }


            lblNome = new Label();
            lblNome.Location = new Point(20, 50);
            lblNome.Text = "Nome: ";
            this.Controls.Add(lblNome);

            rtxtNome = new RichTextBox();
            rtxtNome.Location = new Point(130, 50);
            rtxtNome.Size = new Size(110, 20);
            this.Controls.Add(rtxtNome);

            lblDtNasc = new Label();
            lblDtNasc.Text = "Dt. Nasc:";
            lblDtNasc.Location = new Point(20, 80);
            this.Controls.Add(lblDtNasc);

            txtDtNasc = new MaskedTextBox();
            txtDtNasc.Location = new Point(130, 80);
            txtDtNasc.Size = new Size(110, 20);
            txtDtNasc.Mask = "00/00/0000";
            this.Controls.Add(txtDtNasc);

            lblCpf = new Label();
            lblCpf.Text = "CPF: ";
            lblCpf.Location = new Point(20, 110);
            this.Controls.Add(lblCpf);

            txtCpf = new MaskedTextBox();
            txtCpf.Location = new Point(130, 110);
            txtCpf.Size = new Size(110, 20);
            txtCpf.Mask = "000.000.000-00";
            this.txtCpf.ReadOnly = isUpdate;
            this.Controls.Add(txtCpf);

            lblDiasDev = new Label();
            lblDiasDev.Text = "Dias Dev.: ";
            lblDiasDev.Location = new Point(20, 140);
            this.Controls.Add(lblDiasDev);

            numDiasDev = new NumericUpDown();
            numDiasDev.Location = new Point(130, 140);
            numDiasDev.Size = new Size(110, 20);
            numDiasDev.Maximum = 20;
            numDiasDev.Minimum = 5;
            numDiasDev.Increment = 5;
            numDiasDev.ReadOnly = true;
            this.Controls.Add(numDiasDev);

            btnConfirma = new Button();
            btnConfirma.Size = new Size(80, 20);
            btnConfirma.Location = new Point(20, 300);
            btnConfirma.Text = "Confirma";
            this.Controls.Add(btnConfirma);
            btnConfirma.Click += new EventHandler(btnConfirmaClick);

            btnCancela = new Button();
            btnCancela.Size = new Size(80, 20);
            btnCancela.Location = new Point(150, 300);
            btnCancela.Text = "Cancela";
            this.Controls.Add(btnCancela);
            btnCancela.Click += new EventHandler(btnCancelaClick);
        }
    }
}