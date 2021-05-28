using System;
using Models;
using System.Collections.Generic;
namespace Controllers {
    public class VeiculoController {
        public static void InserirVeiculo(string marca, string sDtLancamento, double valor, int estoque)
        {
            DateTime dtLancamento;
            if(marca.Length==0){
                throw new Exception ("Digite um nome válido");
            }
            try {
                dtLancamento = Convert.ToDateTime (sDtLancamento);
            } catch {
                dtLancamento = DateTime.Now;
            }
            Veiculo.InserirVeiculo (marca, dtLancamento, valor, estoque);
            if(valor <= 0){
                throw new Exception ("Digite um valor válido");
            }
            if (estoque <=0){
                throw new Exception ("Digite a quantidade em estoque");
            }
        }
        public static Veiculo GetVeiculo (int idVeiculos){
            return Veiculo.GetVeiculo(idVeiculos);
        }
        public static List<Veiculo> GetVeiculo (){
            return Veiculo.GetVeiculos();
        }
    }
}