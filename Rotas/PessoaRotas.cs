using apiDotNet.Models;
using System.Reflection.Metadata;

namespace apiDotNet.Rotas
{
    public static class PessoaRotas
    {
        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet(pattern: "/pessoas", handler: () =>  Pessoas );

            app.MapGet(pattern: "/pessoas/{nome}", handler: (string nome) =>
            {
                return Pessoas.Find(x => x.Nome == nome);
            });

            app.MapPost(pattern: "/pessoas", handler: (Pessoa pessoa) =>
            {
                if (pessoa.Nome.Equals("suzana", StringComparison.OrdinalIgnoreCase));
                {
                    return Results.BadRequest(error: new { message = "Erro pos a adm é a suzana" });
                }
                
                {
                    Pessoas.Add(pessoa);
                    return Results.Ok(pessoa);
                }
            }
            });
        }

        public static  List<Pessoa> Pessoas = new()
        {
            new Pessoa(Guid.NewGuid(), nome:"Freddie Mercury"),
            new Pessoa(Guid.NewGuid(), nome:"Jean Poul Sartre"),
            new Pessoa(Guid.NewGuid(), nome:"Sêneca"),
            new Pessoa(Guid.NewGuid(), nome:"Marco Aurélio"),
        };
       
    }
}
