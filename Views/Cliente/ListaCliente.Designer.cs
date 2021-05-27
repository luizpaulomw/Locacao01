using System;
using Models;
using Controllers;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.View;
namespace Views
{
    public partial class ListaClientes : FormBase
    {
        Label lblListaCliente;
        ListView lvClientes;
        Button btnSelecionar;
        Library.Botao.BtnVoltar btnVoltar;
        public void InitializeComponent(){
            this.Text = "Lista Cliente";
            this.BackColor = Color.Beige;
            this.Size = new Size(300,400);

            lblListaCliente = new Label();
            lblListaCliente.Location = new Point(100,10);
            lblListaCliente.Text = "Lista de Clientes";
            this.Controls.Add(lblListaCliente);

            lvClientes = new ListView();
            lvClientes.Size = new Size(250,150);
            lvClientes.Location = new Point (20,50);
            lvClientes.View = Details;
            foreach(Cliente cliente in ClienteController.GetClientes()){
                ListViewItem lvCliente = new ListViewItem(cliente.ClienteId.ToString());
                lvCliente.SubItems.Add(cliente.Nome);
                lvCliente.SubItems.Add(cliente.Cpf);
                lvClientes.Items.Add(lvCliente);
            }
            lvClientes.FullRowSelect = true;
            lvClientes.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lvClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lvClientes.Columns.Add("Cpf", -2, HorizontalAlignment.Left);
            this.Controls.Add(lvClientes);

            btnSelecionar = new Button();
            btnSelecionar.Size = new Size(80, 20);
            btnSelecionar.Location = new Point(20, 300);
            btnSelecionar.Text = "Detalhar";
            this.Controls.Add(btnSelecionar);
            btnSelecionar.Click += new EventHandler(btnSelecionarClick);

            btnVoltar = new Library.Botao.BtnVoltar(180,this,parent);
            this.Controls.Add(btnVoltar);

        }
    }
}