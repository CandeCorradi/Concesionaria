using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Concesionaria.DTO
{
    internal class Propietario
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Telefono { get; set; }
        public string Ciudad { get; set; } = string.Empty;

        [JsonIgnore]
        public string NombreCompleto => $"{Nombre} {Apellido}";

        public override string ToString() => NombreCompleto;
    }
}
