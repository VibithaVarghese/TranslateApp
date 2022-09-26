using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TranslateApp.Controllers
{
    public class Data
    {
        public int ID { get; set; }
        public string TraslatorID { get; set; }
        public string language { get; set; }

        public string ClientId { get; set; }

        public string Value { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class TranslateController : ControllerBase
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-GIE55NI;database=Translate;Integrated Security=SSPI");
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(ILogger<TranslateController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTranslate")]
        public String Get(String translationId, String? language = null, String? clientID = null)
        {
            /*
            * 1. When the lanuage is null then assign the default language
            * as english.
           */
            if (language == null) { language = "en"; }

            /* 
             * 2. When the client ID is null, access
             * the value from the database by passing the 
             * TranslatorID, lanaguage.
            */
            if(clientID == null)
            {
                // select the correct row from the database.
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from TranslatorTable where TraslatorID = '" + translationId + "' AND language = '"+language+ "' AND ClientId is NULL", con);
                // create and dump the data in the datatable
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                // when the data table contains a value reurn the value field otherwise retun the translatorID itself.
                if (dt.Rows.Count > 0)
                {
                    string jsonString = string.Empty;
                    jsonString = JsonConvert.SerializeObject(dt);
                    List<Data> item = JsonConvert.DeserializeObject<List<Data>>(jsonString);
                    foreach (var i in item)
                    {
                        return i.Value;
                    }
                } else
                {
                    return translationId;
                }

            } else
            {
                /* 
                 * 3. When the client ID is not null, access
                 * the value from the database by passing the 
                 * TranslatorID, lanaguage and client ID.
                */
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select * from TranslatorTable where TraslatorID = '" + translationId + "' AND language = '"+language+ "' AND ClientId = '" + clientID+ "'", con);
                DataTable dt1 = new DataTable();
                sqlDataAdapter1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    string jsonString1 = string.Empty;
                    jsonString1 = JsonConvert.SerializeObject(dt1);
                    List<Data> item1 = JsonConvert.DeserializeObject<List<Data>>(jsonString1);
                    foreach (var i in item1)
                    {
                        return i.Value;
                    }
                }
                else
                {
                    return translationId;
                }

            }
            return translationId;

        }
       
    }
}