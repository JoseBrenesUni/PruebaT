using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class GestorDeContactos
    {
        private List<Contacto> contactos = new List<Contacto>();
        private const string FilePath = "contactos.json";

        public GestorDeContactos()
        {
            CargarContactos();
        }

        public void AgregarContacto(Contacto contacto)
        {
            contacto.Id = contactos.Any() ? contactos.Max(c => c.Id) + 1 : 1;
            contactos.Add(contacto);
        }

        public List<Contacto> BuscarContacto(string criterio)
        {
            return contactos.Where(c => c.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                                        c.Telefono.Contains(criterio, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Contacto> ListarContactos()
        {
            return contactos;
        }

        public bool EliminarContacto(int id)
        {
            var contacto = contactos.FirstOrDefault(c => c.Id == id);
            if (contacto != null)
            {
                contactos.Remove(contacto);
                return true;
            }
            return false;
        }

        public void GuardarContactos()
        {
            var json = JsonSerializer.Serialize(contactos);
            File.WriteAllText(FilePath, json);
        }

        private void CargarContactos()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                contactos = JsonSerializer.Deserialize<List<Contacto>>(json) ?? new List<Contacto>();
            }
        }
    }
}
