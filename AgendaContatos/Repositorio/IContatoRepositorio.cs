using AgendaContatos.Models;

namespace AgendaContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
