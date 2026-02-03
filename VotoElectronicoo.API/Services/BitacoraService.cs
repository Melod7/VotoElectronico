using Microsoft.AspNetCore.Http;
using System;
using VotoElectronico.API.Data;
using VotoElectronicoo.API.Models;


namespace VotoElectronicoo.API.Services
{
    public class BitacoraService
    {
        private readonly VotoElectronicoContext _context;
        private readonly IHttpContextAccessor _http;

        public BitacoraService(
            VotoElectronicoContext context,
            IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        public void Registrar(string rol, string accion, string descripcion)
        {
            var ip = _http.HttpContext?.Connection.RemoteIpAddress?.ToString();

            _context.Bitacoras.Add(new Bitacora
            {
                Rol = rol,
                Accion = accion,
                Descripcion = descripcion,
                Fecha = DateTime.UtcNow,
                Ip = ip
            });

            _context.SaveChanges();
        }
    }
}


