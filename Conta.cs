using System;
using DigiBank.Contratos;

namespace DigiBank
{
    public abstract class Conta : Banco, IConta
    {
        // construtor
        public Conta()
        {
            this.NumeroAgencia = "0001"; // numero inicial da conta
            Conta.NumeroContaSequencia++; // chamamos como Conta. pq é static. A cada nova conta criada, um numero será acrescentado
        }

        //atributos
        public double Saldo {get; protected set;}
        public string NumeroAgencia {get; private set;}//usar private no set 
        public string NumeroConta {get; protected set;} //usar private no set 
         public static int NumeroContaSequencia {get; private set;}
        
        //metodos
        public double ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public bool Saca(double valor)
        {
           if(valor > this.ConsultarSaldo())
           return false;
            //else
           this.Saldo -= valor;
           return true;
        }
        public string GetCodigoBanco()
        {
            return this.CodigoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
           return this.NumeroConta;
        }

    }
}
