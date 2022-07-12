using Jcf.QuinzePontos.Dominio.IServicos;

namespace Jcf.QuinzePontos.Infraestrutura.Servicos
{
    public class TratamentoServico : ITratamentoServico
    {
        public string TratarDataString(int concurso, string ValorAtual)
        {           
            var retorno = concurso switch
            {
                2384 => "30/11/2021",
                2386 => "02/12/2021",
                2389 => "06/12/2021",
                2392 => "09/12/2021",  
                _ => ValorAtual,
            };
            return retorno;
        }
    }
}
