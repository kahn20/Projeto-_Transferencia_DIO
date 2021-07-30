using System;
namespace DIO.Bank
{
    public class Conta
    {  
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //vallidação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo insuficiente");
                return false; //retorna para quem chamou informando false
            }
             
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é  {1}", this.Nome, this.Saldo);
            //https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting
            // doc explicando como formatar saida usando string e os atributos
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){ //a transferencia inicia com um sque 
                contaDestino.Depositar(valorTransferencia); //utiliza o metodo depositar da classe conta
            }
        }

        public override string ToString()
        { 
            string retorno = "";
            retorno +="TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito; 
            return retorno;
        }
    }
}