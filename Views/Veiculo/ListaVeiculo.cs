using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;
using static System.Windows.Forms.View;
namespace Views
{
    public class ListaVeiculo : FormBase
    {
        Form parent;
        Label listaDeVeiculos;
        ListView lvVeiculos;
        Library.Botao btnDetalhaVeiculo;
        Library.Botao.BtnVoltar btnCancela;
        private Veiculo veiculo;

        public ListaVeiculo(Form parent){
            this.parent = parent;
            this.Text = "Lista Veiculos";

            listaDeVeiculos = new Label();
            listaDeVeiculos.Location = new Point(100,30);
            listaDeVeiculos.Text = "Lista de Veiculos";
            this.Controls.Add(listaDeVeiculos);

            lvVeiculos = new ListView();
            lvVeiculos.Size = new Size(250,200);
            lvVeiculos.Location = new Point(20,60);
            lvVeiculos.View = Details;
            ListViewItem veiculos = new ListViewItem();
            System.Collections.IList list = VeiculoController.GetVeiculos();
            for (int i = 0; i < list.Count; i++)
            {
                Veiculos veiculo = (Veiculos)list[i];
                ListViewItem lvVeiculo = new ListViewItem(veiculo.VeiculoId.ToString());
                lvVeiculo.SubItems.Add(veiculo.marca);
                lvVeiculo.SubItems.Add(veiculo.Valor.ToString());
                //lvVeiculo.SubItems.Add(lvVeiculos);
            }
            lvVeiculos.FullRowSelect = true;
            lvVeiculos.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lvVeiculos.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lvVeiculos.Columns.Add("Valor", -2, HorizontalAlignment.Left);
            this.Controls.Add(lvVeiculos);

            btnDetalhaVeiculo = new Library.Botao();
            btnDetalhaVeiculo.Location = new Point(20, 300);
            btnDetalhaVeiculo.Text = "Detalha";
            this.Controls.Add(btnDetalhaVeiculo);
            btnDetalhaVeiculo.Click += new EventHandler(btnDetalhaVeiculoClick);

            btnCancela = new Library.Botao.BtnVoltar(180,this,parent);
            this.Controls.Add(btnCancela);
        }
         private void btnDetalhaVeiculoClick(object sender, EventArgs e)
        {
            try{
            string veiculoId = this.lvVeiculos.SelectedItems[0].Text;
          //  Veiculos veiculos = VeiculoController.GetVeiculo(Int32.Parse(VeiculoId));
            DetalhaVeiculo btnSelecionarClick = new DetalhaVeiculo(this,veiculo);
            btnSelecionarClick.Show() ;
            this.Hide();
            }catch (Exception err){
                MessageBox.Show(err.Message, "Selecione um veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class Veiculos
        {
            internal object VeiculoId;
            internal ListViewItem.ListViewSubItem marca;

            public object Valor { get; internal set; }
        }
    }
}