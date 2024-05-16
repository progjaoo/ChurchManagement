namespace ChurchManagement.Application.ViewModels.PostsVMs
{
    public class PostViewModel
    {
        public PostViewModel(int idPost, string titulo, string assunto) //GetAll
        {
            IdPost = idPost;
            Titulo = titulo;
            Assunto = assunto;
        }

        public PostViewModel(int idPost, string titulo, string assunto, byte[] imagem) //GetById
        {
            IdPost = idPost;
            Titulo = titulo;
            Assunto = assunto;
            Imagem = imagem;
        }
        public int IdPost { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public byte[] Imagem { get; set; }

    }
}
