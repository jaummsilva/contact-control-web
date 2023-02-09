namespace ContatosMVC.Helpers
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
