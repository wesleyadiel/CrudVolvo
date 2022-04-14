using Volvo.Data;

namespace CrudVolvo.Services
{
    public class CaminhaoService
    {
        private readonly VolvoDBContext context;

        public CaminhaoService(VolvoDBContext context)
        { 
            this.context = context;
        }

        public List<Caminhao> GetAll()
        {
            try
            {
                return this.context.Caminhoes.OrderBy(c => c.Id).ToList();
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
        public Caminhao FindById(int id)
        {
            try
            {
                return this.context.Caminhoes.Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Editar(Caminhao caminhao)
        {
            try
            {
                this.context.Caminhoes.Update(caminhao);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Adicionar(Caminhao caminhao)
        {
            try
            {
                this.context.Caminhoes.Add(caminhao);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Remover(int idCaminhao)
        {
            try
            {
                Caminhao caminhao = FindById(idCaminhao);
                if (caminhao is null)
                {
                    return false;
                }

                this.context.Caminhoes.Remove(caminhao);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remover(Caminhao caminhao)
        {
            try
            {
                this.context.Caminhoes.Remove(caminhao);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
