using System;
using Models;
using System.Collections.Generic;

namespace Controllers {
    public class LocacaoController {
        public static void InserirVeiculo(
            Locacao locacao,
            Veiculo veiculo
        ){
            locacao.InserirVeiculo(veiculo);
        }
        public static List<Locacao> GetLocacoes (){
            return Locacao.GetLocacoes();
        }
        public static double GetValorTotal (Locacao locacao) {
            double valorTotal = 0;
            foreach (VeiculoLocacao veiculo in locacao.Veiculo){
                valorTotal += veiculo.Veiculo.Valor;
            }
            return valorTotal;
        }
        public static DateTime GetDataDevolucao (DateTime DtLocacao, Cliente Cliente) {
            return DtLocacao.AddDays (Cliente.Dias);
        }
    }
}