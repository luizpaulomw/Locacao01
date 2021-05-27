using System;
using System.Drawing;
using System.Windows.Forms;
using Models;
namespace Views
{
    public partial class DetalhaCliente : FormBase
    {
        Form parent;
        Cliente cliente;
        public DetalhaCliente(Form parent, Cliente cliente){
            this.parent = parent;
            this.cliente = cliente;
            InitializeComponent(parent, cliente);
        }
        private void btnLocacaoClick(object sender, EventArgs e)
        {
            CadastraLocacao CadastraLocacaoClick = new CadastraLocacao(this,this.clienteLocal);
            CadastraLocacaoClick.Show();
            this.Hide();
        }
        private void btnAtualizarClick(object sender, EventArgs e)
        {
            CadastraCliente btnAtualizarClick = new CadastraCliente(this,this.clienteLocal);
            btnAtualizarClick.Show();
            this.Hide();
        }
        private void btnDeletarClick(object sender, EventArgs e)
        {
            CadastraLocacao CadastraLocacaoClick = new CadastraLocacao(this,this.clienteLocal);
            CadastraLocacaoClick.Show();
            this.Hide();
        }
    }
}