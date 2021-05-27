using System;
using System.Collections.Generic;
using Repositories;
using System.Linq;
namespace Models {
    public class Veiculo {
        public int VeiculoId { get; set; }
        public string MarcaVeiculo{ get; set; }
        public DateTime DtLancamento { get; set; }
        public double Valor { get; set; }
        public int QtdEstoque { get; set; }
        public ICollection<VeiculoLocacao> Locacoes { get; set; }
        public Veiculo(){
            Locacoes = new List<VeiculoLocacao>();
        }
        public static void InserirVeiculo (string MarcaVeiculo, DateTime dtLancamento, double valor, int qtdEstoque) {
            Veiculo veiculo = new Veiculo {
                MarcaVeiculo = MarcaVeiculo,
                DtLancamento = dtLancamento,
                Valor = valor,
                QtdEstoque = qtdEstoque
            };
            var db = new Context();
            db.Veiculos.Add(veiculo);
            db.SaveChanges();
        }
        public static Veiculo GetVeiculo(int VeiculoId){
            var db = new Context();
            return (from Veiculo in db.Veiculos
                where Veiculo.VeiculoId == VeiculoId
                select Veiculo).First();
        }
        public static List<Veiculo> GetVeiculos(){
            var db = new Context();
            return db.Veiculos.ToList();
        }
        public string ToString (bool simple = false) {
            if (simple) {
                return $"Id: {VeiculoId} - Nome: {MarcaVeiculo}";
            }
            var db = new Context();
            int cnt = 
                (from Veiculo in db.VeiculoLocacao
                    where Veiculo.VeiculoId == VeiculoId
                    select Veiculo.VeiculoId).Count();
            return $"Nome: {MarcaVeiculo}\n" +
                $"Valor: {Valor:C2}\n" +
                $"Quantidade de Locações: {cnt}\n";
        }
    }
}