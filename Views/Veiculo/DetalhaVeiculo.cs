using System;
using System.Drawing;
using System.Windows.Forms;
using Models;
namespace Views
{
    public class DetalhaVeiculo : FormBase
    {
        Form parent;
        Label lblNome;
        RichTextBox rtbSinopse;
        Label lblDtLancamento;
        Label lblValor;
        Label lblQtdEstoque;
        Library.Botao.BtnVoltar btnVoltar;
        int idVeiculo;
        Veiculo veiculoLocal;
        public DetalhaVeiculo(Form parent, Veiculo veiculo){
            this.Size = new Size(300,400);
            this.parent = parent;
            this.idVeiculo=veiculo.VeiculoId;
            this.veiculoLocal = veiculo;
            this.Text = "Veiculo";
            this.BackColor = Color.Beige;

            lblNome = new Label();
            lblNome.Location = new Point(20, 20);
            lblNome.Text = $"Nome: {veiculo.MarcaVeiculo}";
            this.Controls.Add(lblNome);

         
            lblDtLancamento = new Label();
            lblDtLancamento.Location = new Point(20, 180);
            lblDtLancamento.Size = new Size (250,20);
            lblDtLancamento.Text = $"Lançamento: {veiculo.DtLancamento.ToShortDateString()}";
            this.Controls.Add(lblDtLancamento);

            lblValor = new Label();
            lblValor.Location = new Point(20,210);
            lblValor.Size = new Size (150,20);
            lblValor.Text = $"Valor: R$: {veiculo.Valor},00";
            this.Controls.Add(lblValor);

            lblQtdEstoque = new Label();
            lblQtdEstoque.Location = new Point(20,240);
            lblQtdEstoque.Size = new Size (150,20);
            lblQtdEstoque.Text = $"Estoque: {veiculo.QtdEstoque} unidades";
            this.Controls.Add(lblQtdEstoque);

            btnVoltar = new Library.Botao.BtnVoltar(170,this,parent);
            this.Controls.Add(btnVoltar);
        }
    }
}