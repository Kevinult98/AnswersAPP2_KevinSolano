using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;

namespace AnswersAPP2_KevinSolano.Models
{
    public class User
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";

        public User()
        {
            request = new RestRequest();
            Answers = new HashSet<Answer>();
            Asks = new HashSet<Ask>();
            ChatReceivers = new HashSet<Chat>();
            ChatSenders = new HashSet<Chat>();
            Likes = new HashSet<Like>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; }
        public string JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<Chat> ChatReceivers { get; set; }
        public virtual ICollection<Chat> ChatSenders { get; set; }
        public virtual ICollection<Like> Likes { get; set; }


        public async Task<bool> AddNewUser()
        {

            bool R = false;

            try
            {
                //Se adjunta a la url base la dirección del recurso que queremos consumir
                string FinalApiRoute = CnnToApi.ProductionRoute + "users";

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);

                
                //agregar la info de seguridad, en este caso api key 
                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                //serializar esta clase para pasarla en el body 
                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass, mimetype);

                //esto envía la consulta al api y recibe una respuesta que debemos leer 
                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }
            return R;
        }

        //Funcion para validar el acceso del usuario en el sistema

        public async Task<bool> ValidateUserAccess()
        {
            bool R = false;


            try
            {
                //como esta ruta es un poco más compleja de consumir ya que lleva una función con nombre y además dos parámetros
                //lo más conveniente es formatearla por aparte y luego adjuntarla a Base URL (CnnToApi.ProductionRoute)
                //para obtener la ruta completa
                string routeSufix = string.Format("users/ValidateUserLogin?pEmail={0}&pPassword={1}" , this.UserName, this.UserPassword);
                string FinalApiRoute = CnnToApi.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

            return R;
        }
    }
}
