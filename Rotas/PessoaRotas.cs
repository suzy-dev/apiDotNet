using apiDotNet.Models;
using System.Reflection.Metadata;

namespace apiDotNet.Rotas
{
    public static class PessoaRotas
    {
        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet(pattern: "/pessoas", handler: () =>  Pessoas );

            app.MapPost(pattern: "/pessoas", handler: (Pessoa pessoa) =>
            {
                if (pessoa.Nome.Equals("suzana", StringComparison.OrdinalIgnoreCase))
                {
                    return Results.BadRequest(error: new { message = "Erro pos a adm é a suzana" });
                }
                else
                {
                    Pessoas.Add(pessoa);
                    return Results.Ok(pessoa);
                }
            });

            app.MapPut(pattern: "/pessoas/{id}", handler: (Guid id, Pessoa pessoa) =>
            {
                Pessoa? encontrado = Pessoas.Find(x => x.Id == id);
                if (encontrado == null)
                    return Results.NotFound();
                else
                    encontrado.Nome = pessoa.Nome;
                return Results.Ok(encontrado);
            });
        }

        public static List<Pessoa> Pessoas = new()
        {
            new Pessoa(Guid.NewGuid(), nome:"Freddie Mercury"),
            new Pessoa(Guid.NewGuid(), nome:"Jean Poul Sartre"),
            new Pessoa(Guid.NewGuid(), nome:"Sêneca"),
            new Pessoa(Guid.NewGuid(), nome:"Marco Aurélio")
        };
    }
}
