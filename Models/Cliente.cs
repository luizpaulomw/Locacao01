using System;
using System.Collections.Generic;
using Repositories;
using Controllers;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace Models {
    public class Cliente {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        public DateTime DtNasc { get; set; }
        public string Cpf { get; set; }
        public int Dias { get; set; }
        public ICollection<Locacao> Locacoes { get; set; }
        public Cliente(){
            Locacoes = new List<Locacao>();
        }
        public static void InserirCliente (string nome, DateTime dtNasc, string cpf, int dias) {
            Cliente cliente = new Cliente {
                Nome = nome,
                DtNasc = dtNasc,
                Cpf = cpf,
                Dias = dias,
                Locacoes = new List<Locacao> ()
            };
            var db = new Context();
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }
        public static void AtualizarCliente(int idCliente, string nome, DateTime dtNasc, string cpf, int dias)
        {
            Context db = new Context();
            try
            {
                Cliente cliente = db.Clientes.First(cliente => cliente.ClienteId == idCliente);
                cliente.Nome = nome;
                cliente.DtNasc = dtNasc;
                cliente.Cpf = cpf;
                cliente.Dias = dias;
                db.SaveChanges();
            }
            catch
            {
                throw new ArgumentException();
            }
        }
        public static void DeleteCliente(int id)
        {
            Context db = new Context();
            try
            {
                Cliente cliente = db.Clientes.First(cliente => cliente.ClienteId == id);
                db.Remove(cliente);
                try
                {
                    db.SaveChanges();
                } catch 
                    {
                    //throw error();
                    }
            }catch
                {
                    //throw error}
                }
        }

        public void InserirLocacao (Locacao locacao) {
            Locacoes.Add (locacao);
        }
        
        public static Cliente GetCliente(int ClienteId){
            var db = new Context();
            return (from cliente in db.Clientes
                where cliente.ClienteId == ClienteId
                select cliente).First();
        }

        public static List<Cliente> GetClientes(){
            var db = new Context();
            return db.Clientes.ToList();
        }

        public string ToString (bool simple = false) {
            Context db = new Context();
            List<Locacao> LocacoesList = (
                    from locacao in db.Locacoes
                    where locacao.ClienteId == ClienteId
                    select locacao).ToList();
            if (simple) {
                string retorno = $"Id: {ClienteId} - Nome: {Nome}\n" +
                    "   Locações: \n";
                if (LocacoesList.Count > 0) {
                    LocacoesList.ForEach (
                        locacao => retorno += $"    Id: {locacao.LocacaoId} - " +
                        $"Data: {locacao.DtLocacao} - " +
                        $"Data de Devolução: {LocacaoController.GetDataDevolucao(locacao.DtLocacao, this)}\n"
                    );
                } else {
                    retorno += "    Não há locações";
                }
                return retorno;
            }
            int qtdFilmes = 0;
            foreach(Locacao locacao in LocacoesList){
                qtdFilmes += (from filme in db.VeiculoLocacao
                    where filme.LocacaoId == locacao.LocacaoId
                    select filme).Count();
            }
            string dtNasc = DtNasc.ToString("dd/MM/yyyy");
            return $"Nome: {Nome}\n" +
                $"Data de Nasciment: {dtNasc}\n" +
                $"Qtd de Filmes: {qtdFilmes}";
        }
    }
}