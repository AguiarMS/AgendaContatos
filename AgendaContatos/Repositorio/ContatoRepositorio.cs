using AgendaContatos.Data;
using AgendaContatos.Models;

namespace AgendaContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public ContatoModel ListarId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        //Carrega toda lista de contato.
        public List<ContatoModel> BuscarTodos()
        {
           return _context.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarId(contato.Id);
            if (contatoDB == null) throw new System.Exception("Erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;
            contatoDB.Observacao = contato.Observacao;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarId(id);
            if (contatoDB == null) throw new System.Exception("Erro na exclusão do contato");
            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
