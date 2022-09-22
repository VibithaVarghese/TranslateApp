using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace TranslateApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslateController : ControllerBase
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-GIE55NI; database=TranslatorTable; Uid=auth_windows");
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(ILogger<TranslateController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTranslate")]
        public String Get(String translationId, String? language = null, String? clientID = null)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from TranslatorTable where TraslatorID = 'PermitName' AND ClientId is NULL", con);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return "very good";

            }

            /*
             * 1. When the lanuage is null then assign the default language
             * as english.
            */
            if (language == null) { language = "en"; }

            /* 
             * 2. Here access the correct value from the DB with giving 
             * translationId, language & clientID.
             * Current database have the following fields:
             * 
            */




            return translationId;


        }
       
    }
}