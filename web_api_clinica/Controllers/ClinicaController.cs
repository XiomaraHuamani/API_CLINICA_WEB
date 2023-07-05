using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using web_api_clinica.Controllers;
using web_api_clinica.Models;

namespace web_api_clinica.Controllers
{
    [ApiController]
    [Route("clinica")]
    public class ClinicaController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarClinica()
        {
            List<Clinica> Clinicas = new List<Clinica>
            { 
                new Clinica
                { 
                    id = "1",
                    nombre_doctor = "Dereck shepart",
                    especialidad = "nerurologia",
                    turno = "Mañana",
                    horario = "8:00 - 12:00"
                },
                new Clinica
                {
                    id = "2",
                    nombre_doctor = "Francisco lizarraga",
                    especialidad = "dermatologia",
                    turno = "Tarde",
                    horario = "12:00 - 4:00"
                },
                new Clinica
                {
                    id = "3",
                    nombre_doctor = "Cristina Yang",
                    especialidad = "cardiologia",
                    turno = "Mañana",
                    horario = "4:00 - 8:00"
                }
            };
            return Clinicas;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClinicaxid(int codigo)
        {
            return new Clinica
            {
                id = codigo.ToString(),
                nombre_doctor = "Meredid Gray",
                especialidad = "cirujia general",
                turno = "Mañana",
                horario = "4:00 - 8:00"

            };

        }
        [HttpPost]
        [Route("guardar")]
        public dynamic guardarClinica(Clinica clinica)
        {
            clinica.id = "3";

            return new 
            {
                success = true,
                message = "datos registrados",
                result = clinica
            };

        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarClinica(Clinica clinica)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if (token != "xiomara123.")
            {
                return new
                {
                    success = true,
                    message = "token incorrecto",
                    result = ""
                };
            }
            return new
            {
                success = true,
                message = "datos registrados",
                result = clinica
            };

        }

    }
}
