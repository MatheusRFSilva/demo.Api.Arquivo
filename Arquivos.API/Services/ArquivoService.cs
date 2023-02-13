using System.IO;

namespace Arquivos.API.Services
{
    public class ArquivoService
    {
        private readonly string _path = @"C:\";

        public async Task<bool> SaveFile(IFormFile file)
        {
            try
            {
                var PastaDestino = Path.Combine(_path, "imagens");
                var destino = Path.Combine(PastaDestino, file.FileName);
                if (!Directory.Exists(PastaDestino))
                    Directory.CreateDirectory(PastaDestino);
                if(File.Exists(destino))
                    File.Delete(destino);

                using (var stream = new FileStream(destino, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return File.Exists(destino);

            }
            catch (Exception ex)
            {

                throw ;
            }

        }
    }
}
