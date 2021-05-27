using System;
using System.Windows.Forms;
using System.Drawing;

namespace Library
{
    public class Botao : System.Windows.Forms.Button
    {
        public Botao(){
        this.Size = new Size(80, 20);
        this.BackColor = Color.FloralWhite;
        }
        public class BtnVoltar : Botao
        {
            Form parent;
            Form formAtual;
            public BtnVoltar(int x, Form formAtual, Form parent)
            {
                this.Text = "Voltar";
                this.Location = new Point( x, 300);
                this.parent = parent;
                this.formAtual = formAtual;
                this.Click += new EventHandler(this.Voltar);
            }
            public void Voltar(object sender, EventArgs args){
                this.parent.Show();
                this.formAtual.Close();
            }
        }
    }
}