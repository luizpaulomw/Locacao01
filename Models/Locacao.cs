using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Repositories;
using System.ComponentModel.DataAnnotations;
using Models;
using static System.Windows.Forms.View;
namespace Models
{
    public class Locacao
    {

        public Locacao(int locacaoId, int clienteId, DateTime dtLocacao)
        {
            this.LocacaoId = locacaoId;
            this.ClienteId = clienteId;
            this.DtLocacao = dtLocacao;

        }
      
        public int LocacaoId { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual Veiculo Veiculos { get; set; }
        [Required]
        public DateTime DtLocacao { get; set; }
        public ICollection<VeiculoLocacao> Veiculo { get; set; }


        public Locacao()
        {
            Veiculo = new List<VeiculoLocacao>();
        }
        public static Locacao InserirLocacao(Cliente cliente, DateTime dtLocacao)
        {
            Locacao locacao = new Locacao
            {
                ClienteId = cliente.ClienteId,
                DtLocacao = dtLocacao,
                Veiculo = new List<VeiculoLocacao>()
            };
            cliente.InserirLocacao(locacao);
            var db = new Context();
            db.Locacoes.Add(locacao);
            db.SaveChanges();
            return locacao;
        }
        public void InserirVeiculo(Veiculo veiculo)
        {
            var db = new Context();
            VeiculoLocacao VeiculoLocacao = new VeiculoLocacao()
            {
                VeiculoId = veiculo.VeiculoId,
                LocacaoId = LocacaoId
            };
            db.VeiculoLocacao.Add(VeiculoLocacao);
            db.SaveChanges();
            Veiculo.Add(VeiculoLocacao);
            veiculo.Locacoes.Add(VeiculoLocacao);
        }
        /*public override string ToString()
        {
            var db = new Context();
            Cliente cliente = (
                    from cli in db.Clientes
                    where cli.ClienteId == ClienteId
                    select cli).First();
            string retorno = $"Cliente: {cliente.Nome}\n" +
                $"Data da Locacao: {DtLocacao}\n" +
                $"Data de Devolucao: {LocacaoController.GetDataDevolucao(DtLocacao, cliente)}\n";
            double valorTotal = 0;
            string strVeiculos = "";
            IEnumerable<int> veiculos =
                from Veiculo in db.VeiculoLocacao
                where Veiculo.LocacaoId
                == LocacaoId
                select Veiculo.VeiculoId;
            if (veiculos.Count() > 0)
            {
                foreach (int id in veiculos)
                {
                    Veiculo veiculo = Veiculo.GetVeiculos();
                    strVeiculos += $"    Id: {veiculo.VeiculoId} - Nome: {veiculo.MarcaVeiculo}\n";
                    valorTotal += veiculo.Valor;
                }
            }
            else
            {
                strVeiculos += "    Não há V";
            }
            retorno += $"Valor Total: {valorTotal:C2}\n" +
                "   Veiculos:\n" +
                strVeiculos;
            return retorno;
        }*/
        public static List<Locacao> GetLocacoes()
        {
            var db = new Context();
            return db.Locacoes.ToList();
        }
        public void setCliente()
        {
            Cliente = Cliente.GetCliente(ClienteId);
        }
        public void setLocacaoVeiculo()
        {
            Veiculo = VeiculoLocacao.GetVeiculoLocacao(LocacaoId);
        }
    }
}