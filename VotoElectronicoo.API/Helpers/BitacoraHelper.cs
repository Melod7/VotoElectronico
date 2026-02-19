using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;

namespace VotoElectronico.API.Helpers
{
    public static class BitacoraHelper
    {
        public static void Registrar(
            VotoElectronicoContext context,
            string rol,
            string accion
        )
        {
            var bitacora = new Bitacora
            {
                Rol = rol,
                Accion = accion,
                Fecha = DateTime.Now
            };

            context.Bitacoras.Add(bitacora);
            context.SaveChanges();
        }
    }
}