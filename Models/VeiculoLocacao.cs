using System;
using System.Collections.Generic;
using System.Linq;
using Repositories;
namespace Models {
    public class VeiculoLocacao {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public int LocacaoId { get; set; }
        public virtual Locacao Locacao { get; set; }
        public static List<VeiculoLocacao> GetVeiculoLocacao(int LocacaoId){
            var db = new Context();
            return (from VeiculoLocacao in db.VeiculoLocacao
                where VeiculoLocacao.LocacaoId == LocacaoId
                select VeiculoLocacao).ToList();
        }
        public void setFilme(){
            var db = new Context();
            Veiculo = (from Veiculo in db.Veiculos
                where Veiculo.VeiculoId == VeiculoId
                select Veiculo).First();
        }
    }
}