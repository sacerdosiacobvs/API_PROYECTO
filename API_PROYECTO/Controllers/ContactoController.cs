using Microsoft.AspNetCore.Mvc;
using System.Data;
using API_PROYECTO.Models;
using System.Collections;
using Nancy.Json;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PROYECTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        [Route("Obtener_Contactos")]
        //[HttpGet("{id}")]
        //public string Obtener_Contactos(int id)
        public string Obtener_Contactos()
        {
            Contacto contacto = new Contacto();

            DataTable dt = contacto.Obtener_Contactos_Tabla();


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows).ToUpper();
        }

    }
}
