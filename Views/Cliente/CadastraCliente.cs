using System;
using System.Windows.Forms;
using Controllers;
using Models;
namespace Views
{
    public partial class CadastraCliente : FormBase
    {
        Form parent;
        Cliente cliente;
        public CadastraCliente(Form parent, Cliente cliente=null)
        {
            this.parent = parent;
            this.cliente = cliente;
            this.Text = "Cadastra Cliente";

            InitializeComponent(parent, cliente!=null);
        }
        private void LoadForm(object sender, EventArgs e ){
            this.txtCpf.Text = cliente.Cpf;
            this.rtxtNome.Text = cliente.Nome;
            this.txtDtNasc.Text = cliente.DtNasc.ToShortDateString();
            this.numDiasDev.Value = cliente.Dias;
        }
        private void btnConfirmaClick(object sender, EventArgs e)
        {
            if (cliente == null){
                try{
                    ClienteController.InserirCliente(this.rtxtNome.Text,this.txtDtNasc.Text, this.txtCpf.Text, (int)this.numDiasDev.Value);
                    MessageBox.Show(
                        $"CADASTRADO!!\n\n" +
                        $"Nome: {this.rtxtNome.Text}\n" +
                        $"Data Nasc: {this.txtDtNasc.Text}\n" +
                        $"CPF: {this.txtCpf.Text}\n" +
                        $"DiasDev: {this.numDiasDev.Value}",
                        "Cliente",
                        MessageBoxButtons.OK
                    );
                    this.Close();
                    this.parent.Show();  
                }catch (Exception err){
                    MessageBox.Show(err.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ClienteController.AtualizarCliente(cliente.ClienteId, this.rtxtNome.Text,this.txtDtNasc.Text, this.txtCpf.Text, (int)this.numDiasDev.Value);
                 MessageBox.Show(
                        $"ATUALIZADO!! \n\n" +
                        $"Nome: {this.rtxtNome.Text}\n" +
                        $"Data Nasc: {this.txtDtNasc.Text}\n" +
                        $"CPF: {this.txtCpf.Text}\n" +
                        $"DiasDev: {this.numDiasDev.Value}",
                        "Cliente",
                        MessageBoxButtons.OK
                    );
                this.Close();
                this.parent.Show();
            }
        }
        public void btnCancelaClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}