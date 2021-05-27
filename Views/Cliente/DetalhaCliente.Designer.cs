using System;
using System.Drawing;
using System.Windows.Forms;
using Models;
namespace Views
{
    public partial class DetalhaCliente : FormBase
    {
        Label lblDetalhaCliente;
        Library.Botao btnLocacao;
        Library.Botao btnAtualizar;
        Library.Botao btnDeletar;
        Library.Botao.BtnVoltar btnVoltar;
        Label lblNome;
        Label lblCpf;
        Label lblDiasDev;
        Label lblDtNasc;
        int idCliente;
        Cliente clienteLocal;

        public void InitializeComponent(Form parent, Cliente cliente){
            this.parent = parent;
            this.idCliente=cliente.ClienteId;
            this.clienteLocal = cliente;
            this.Text = "Detalha Cliente";

            lblDetalhaCliente = new Label();
            lblDetalhaCliente.Location = new Point(90,30);
            lblDetalhaCliente.AutoSize = true;
            lblDetalhaCliente.Text = "Detalhes do Cliente";
            this.Controls.Add(lblDetalhaCliente);

            lblNome = new Label();
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 60);
            lblNome.Text = $"Nome: {cliente.Nome}";
            this.Controls.Add(lblNome);

            lblCpf = new Label();
            lblCpf.Location = new Point(20, 90);
            lblCpf.AutoSize = true;
            lblCpf.Text = $"CPF: {cliente.Cpf}";
            this.Controls.Add(lblCpf);

            lblDiasDev = new Label();
            lblDiasDev.Location = new Point(20, 120);
            lblDiasDev.AutoSize = true;
            lblDiasDev.Text = $"Dias Devolução: {cliente.Dias.ToString()}";
            this.Controls.Add(lblDiasDev);

            lblDtNasc = new Label();
            lblDtNasc.Location = new Point(20, 150);
            lblDtNasc.AutoSize = true;
            lblDtNasc.Text = $"Data de Nascimento: {cliente.DtNasc.ToShortDateString()}";
            this.Controls.Add(lblDtNasc);

            btnLocacao = new Library.Botao();
            btnLocacao.Location = new Point(20, 300);
            btnLocacao.Text = "Nova Locação";
            this.Controls.Add(btnLocacao);
            btnLocacao.Click += new EventHandler(btnLocacaoClick);

            btnAtualizar= new Library.Botao();
            btnAtualizar.Location = new Point(20, 250);
            btnAtualizar.Text = "Atualizar";
            this.Controls.Add(btnAtualizar);
            btnAtualizar.Click += new EventHandler(btnAtualizarClick);

            btnDeletar= new Library.Botao();
            btnDeletar.Location = new Point(170, 250);
            btnDeletar.Text = "Deletar";
            this.Controls.Add(btnDeletar);
            btnDeletar.Click += new EventHandler(btnDeletarClick);

            btnVoltar = new Library.Botao.BtnVoltar(170,this,parent);
            this.Controls.Add(btnVoltar);
        }
    }
}