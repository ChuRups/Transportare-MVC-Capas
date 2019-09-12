using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Modelos;

namespace BAL.Interfaces
{
    public interface IRepositorioMensajeros
    {
        void AgregarMensajero(ModeloMensajeros model);
        void EliminarMensajero(int id);
        void EditarMensajero(ModeloMensajeros model);
        List<ModeloMensajeros> ListarMensajeros();
        ModeloMensajeros ListarMensajeroId(int id);
    }
}
