using System;
using System.Windows.Forms;
using System.Drawing;
using Repositories;

namespace Views
{
    public class TelaInicial : Form
    {
        Label lblTitulo;
        Library.Botao btnCadastraCliente;
        Library.Botao btnListaClientes;
        Library.Botao btnCadastraVeiculo;
        Library.Botao btnListaVeiculos;
        Library.Botao btnSair;
        public TelaInicial()
        {
            this.Text = "Locadora de Carro";
            lblTitulo = new Label();
            lblTitulo.Text = "  ";
            lblTitulo.Location = new Point(110,10);
            this.Controls.Add(lblTitulo);
            
            btnCadastraCliente = new Library.Botao();
            btnCadastraCliente.Size = new Size(200, 20);
            btnCadastraCliente.Location = new Point(40, 50);
            btnCadastraCliente.Text = "Cadastrar Cliente";
            this.Controls.Add(btnCadastraCliente);
            btnCadastraCliente.Click += new EventHandler(btnCadastraClienteClick);

            btnListaClientes = new Library.Botao();
            btnListaClientes.Size = new Size(200, 20);
            btnListaClientes.Location = new Point(40, 80);
            btnListaClientes.Text = "Listar Clientes";
            this.Controls.Add(btnListaClientes);
            btnListaClientes.Click += new EventHandler(btnListaClientesClick);

            btnCadastraVeiculo = new Library.Botao();
            btnCadastraVeiculo.Location = new Point(40, 110);
            btnCadastraVeiculo.Size = new Size(200, 20);
            btnCadastraVeiculo.Text = "Cadastra Veiculo";
            this.Controls.Add(btnCadastraVeiculo);
            btnCadastraVeiculo.Click += new EventHandler(CadastraVeiculoClick);

            btnListaVeiculos = new Library.Botao();
            btnListaVeiculos.Location = new Point(40, 140);
            btnListaVeiculos.Size = new Size(200, 20);
            btnListaVeiculos.Text = "Lista de Veiculos";
            this.Controls.Add(btnListaVeiculos);
            btnListaVeiculos.Click += new EventHandler(btnListaVeiculosClick);

            btnSair = new Library.Botao();
            btnSair.Location = new Point(40, 300);
            btnSair.Size = new Size(200, 20);
            btnSair.Text = "Sair";
            this.Controls.Add(btnSair);
            btnSair.Click += new EventHandler(btnSairClick);
        }
        public void btnCadastraClienteClick(object sender, EventArgs e)
        {
            CadastraCliente cadastraCliente = new CadastraCliente(this);
            cadastraCliente.Show();
            this.Hide();
        }
        private void btnListaClientesClick(object sender, EventArgs e)
        {
            ListaClientes listaClientes = new ListaClientes(this);
            listaClientes.Show();
            this.Hide();
        }
        private void CadastraVeiculoClick(object sender, EventArgs e)
        {
            CadastraVeiculo CadastraVeiculoClick = new CadastraVeiculo(this);
            CadastraVeiculoClick.Show();
            this.Hide();
        }          private void btnListaFilmesClick(object sender, EventArgs e)
        {
            try{
                ListaVeiculo ListaVeiculoClick = new ListaVeiculo(this);
                ListaVeiculoClick.Show();
                this.Hide();
            }catch(Exception err){
                MessageBox.Show(err.Message, "impossivel conectar ao banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnListaVeiculosClick(object sender, EventArgs e)
        {
            
        }

        private void btnSairClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }
    }
}