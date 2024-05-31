using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class PDFGenerator : IPDFGenerator
    {
        public async Task<byte[]> GenerateMemberCardAsync(Membro membro)
        {
            using (var stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf); 

                document.Add(new Paragraph("Carteirinha de Membro")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(18)
                    .SetBold());

                if (membro.ImagemMembro != null)
                {
                    ImageData imageData = ImageDataFactory.Create(membro.ImagemMembro);
                    Image img = new Image(imageData).SetWidth(100).SetHeight(100);
                    document.Add(img);
                }

                document.Add(new Paragraph($"Nome Completo: {membro.NomeCompleto}"));
                document.Add(new Paragraph($"Data de Nascimento: {membro.DataNasc?.ToString("dd/MM/yyyy")}"));
                document.Add(new Paragraph($"Cargo: {membro.Cargo}"));
                document.Add(new Paragraph($"Estado Civil: {membro.EstadoCivil}"));
                document.Add(new Paragraph($"Endereço: {membro.Endereco}"));
                document.Add(new Paragraph($"Telefone: {membro.Telefone}"));
                document.Add(new Paragraph($"Email: {membro.Email}"));
                document.Add(new Paragraph($"Data de Cadastro: {membro.DataCadastro?.ToString("dd/MM/yyyy")}"));
                document.Add(new Paragraph($"Data de Batismo: {membro.DataBatismo?.ToString("dd/MM/yyyy")}"));

                document.Close();
                return stream.ToArray();
            }
        }
    }
}
