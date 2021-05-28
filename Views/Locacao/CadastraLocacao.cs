using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;
using static System.Windows.Forms.View;
namespace Views
{
    public class CadastraLocacao : Form {
        Form parent;
        Label lblCadastraLocação;
        Label lblCliente;
        Label lblVeiculo;
        ListView lvVeiculos;
        Library.Botao btnConfirma;
        Library.Botao.BtnVoltar btnCancela;
        Cliente clienteLocal;
        Locacao locacao;
        public CadastraLocacao(Form parent,Cliente clienteDetalhaCliente){
            this.parent = parent;
            this.clienteLocal = clienteDetalhaCliente;
            this.Text = "Locacao";
            this.BackColor = Color.Beige;
            this.Size = new Size(300,400);

            lblCadastraLocação = new Label();
            lblCadastraLocação.Location = new Point(100,30);
            lblCadastraLocação.Text = "Cadastra Cliente";
            this.Controls.Add(lblCadastraLocação);

            lblCliente = new Label();
            lblCliente.Location = new Point(20,60);
            lblCliente.Text = clienteLocal.Nome;
            this.Controls.Add(lblCliente);

            lblVeiculo = new Label();
            lblVeiculo.Location = new Point(20,90);
            lblVeiculo.Text = "Veiculo";
            this.Controls.Add(lblVeiculo);

            lvVeiculos = new ListView();
            lvVeiculos.Size = new Size(200,100);
            lvVeiculos.Location = new Point(20,120);
            lvVeiculos.View = Details;
            ListViewItem veiculos = new ListViewItem();
            lvVeiculos.CheckBoxes = true;
            foreach (Veiculo veiculo in VeiculoController.GetVeiculo())
            {
                ListViewItem lvVeiculos = new ListViewItem(veiculo.VeiculoId.ToString());
                lvVeiculos.SubItems.Add(veiculo.MarcaVeiculo);
                lvVeiculos.SubItems.Add(veiculo.Valor.ToString());
               // lvVeiculos.SubItems.Add(veiculos);
            }
            lvVeiculos.FullRowSelect = true;
            lvVeiculos.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lvVeiculos.Columns.Add("Marca", -2, HorizontalAlignment.Left);
            lvVeiculos.Columns.Add("Valor", -2, HorizontalAlignment.Left);
            this.Controls.Add(lvVeiculos);
            
            btnConfirma = new Library.Botao();
            btnConfirma.Location = new Point(20, 300);
            btnConfirma.Text = "Confirma";
            this.Controls.Add(btnConfirma);
            btnConfirma.Click += new EventHandler(btnConfirmaClick);

            btnCancela = new Library.Botao.BtnVoltar(120,this,parent);
            this.Controls.Add(btnCancela);
        }
        private void btnConfirmaClick(object sender, EventArgs e)
        {
            locacao=new Locacao();
            locacao.ClienteId=clienteLocal.ClienteId;
            locacao.Cliente=clienteLocal;
            string lstVeiculos = "";
             
                   foreach( ListViewItem Veiculo in lvVeiculos.CheckedItems)
                {
                    lstVeiculos += lstVeiculos + Veiculo.SubItems[1].Text.ToString();
                }
            DialogResult result = MessageBox.Show(
                $"Nome: {this.clienteLocal.Nome}\n" + 
                $"Veiculos Locados: "+lstVeiculos+
                $"Valor da Locação: " ,
                "Confirma Locação?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
           );
            if (result == DialogResult.OK){
                Locacao locacaoLocal = Locacao.InserirLocacao(clienteLocal, DateTime.Now);
               foreach( ListViewItem VeiculoChecado in lvVeiculos.CheckedItems)
                {
                    string VeiculoId = VeiculoChecado.Text;
                    int veiculoId = Convert.ToInt32(VeiculoId);
                    Veiculo veiculo = VeiculoController.GetVeiculo(veiculoId);
                    LocacaoController.InserirVeiculo(locacaoLocal, veiculo);
                }
           }
            this.Close();
            parent.Show();
        }

    }
}