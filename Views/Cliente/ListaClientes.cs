using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;
using static System.Windows.Forms.View;
namespace Views
{
    public partial class ListaClientes : FormBase
    {
        Form parent;

        public ListaClientes(Form parent)
        {    
            this.parent = parent;
            InitializeComponent();
        }
        private void btnSelecionarClick(object sender, EventArgs e)
        {
            try{
                string clienteId = this.lvClientes.SelectedItems[0].Text;
                Cliente cliente = ClienteController.GetCliente(Int32.Parse(clienteId));
                DetalhaCliente btnSelecionarClick = new DetalhaCliente(this, cliente);
                btnSelecionarClick.Show() ;
                this.Hide();
             }catch (Exception err){
                MessageBox.Show(err.Message, "Selecione um cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVoltarClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}