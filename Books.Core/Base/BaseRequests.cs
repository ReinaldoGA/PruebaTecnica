using RestSharp;
 
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers.NewtonsoftJson;

namespace Books.Core.Base
{
    /// <summary>
    /// To get all the endpoint configurations on a inclusive class
    /// </summary>
    public abstract class AbstractBaseRequests : IDisposable
    {
        private bool disposed = false;
        public JsonSerializerSettings? defaultSettings;
        public string? Url { get; set; }
        public RestClient Client { get; set; }
        public RestRequest? Request { get; set; }
        public IList<Tuple<string, string>> Headers { get; set; }
        public IList<Tuple<string, string>> QueryParameters { get; set; }

        public AbstractBaseRequests(string? url )
        {
            this.Url = url;
            this.Client = new RestClient(this.Url != null ? this.Url : "");
            this.Headers = new List<Tuple<string, string>> { Tuple.Create("Content-Type", "application/json") };
            this.QueryParameters = new List<Tuple<string, string>>();
        }

        private RestRequest SetRequest(string route)
        {
            this.Request = new RestRequest(route);
            foreach (var header in this.Headers)
            {
                this.Request.AddHeader(header.Item1, header.Item2);
            }

            foreach (var queryParameter in this.QueryParameters)
            {
                this.Request.AddQueryParameter(queryParameter.Item1, queryParameter.Item2);
            }

            this.QueryParameters.Clear();
            return this.Request;
        }

        private void SetSerializerSettings(string serializer)
        {
            var ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            if (serializer == "snake_case") ContractResolver.NamingStrategy = new SnakeCaseNamingStrategy();
            if (serializer == "PascalCase") ContractResolver.NamingStrategy = new PascalCaseNamingStrategy();
            this.defaultSettings = new JsonSerializerSettings
            {
                ContractResolver = ContractResolver,
                DefaultValueHandling = DefaultValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
            this.Client.UseNewtonsoftJson(this.defaultSettings);
        }

        public void AddBearer(string? JwtToken)
        {
            if (!string.IsNullOrEmpty(JwtToken))
            {
                this.Headers.Add(Tuple.Create("Authorization", $"Bearer {JwtToken}"));
            }
        }

        public void AddHeader(string key, string value)
        {
            this.Headers.Add(Tuple.Create(key, value));
        }

        public void AddQueryParameter(string key, string value)
        {
            this.QueryParameters.Add(Tuple.Create(key, value));
        }

        public string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, this.defaultSettings);
        }

        public async Task<RestResponse<T>> Get<T>(string route = "")
        {
            var request = this.SetRequest(route);
            var response = await this.Client.ExecuteGetAsync<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response;
            }
            throw new RequestBaseException<T>(response.StatusCode, response.Content, this.defaultSettings);
        }

        public async Task<RestResponse<T>> Post<T>(string? route, object? body)
        {
            if (string.IsNullOrEmpty(route)) route = string.Empty;

            var request = this.SetRequest(route);

            if (body != null) request.AddJsonBody(body);

            var response = await this.Client.ExecutePostAsync<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response;
            }
            throw new RequestBaseException<T>(response.StatusCode, response.Content, this.defaultSettings);
        }

        public async Task<RestResponse<T>> PostForm<T>(string? route, object? body)
        {
            if (string.IsNullOrEmpty(route)) route = string.Empty;

            var request = this.SetRequest(route);

            var jsonBody = SerializeObject(body);
            var jsonForm = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonBody);
            if (jsonForm != null)
            {
                foreach (var item in jsonForm)
                {
                    request.AddParameter(item.Key, item.Value);
                }
            }

            var response = await this.Client.ExecutePostAsync<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response;
            }
            throw new RequestBaseException<T>(response.StatusCode, response.Content, this.defaultSettings);
        }

        public async Task<RestResponse<T>> Put<T>(string? route, object? body)
        {
            if (string.IsNullOrEmpty(route)) route = string.Empty;

            var request = this.SetRequest(route);
            if (body != null) request.AddJsonBody(body);

            var response = await this.Client.ExecutePutAsync<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response;
            }
            throw new RequestBaseException<T>(response.StatusCode, response.Content, this.defaultSettings);
        }

        public async Task<T> Patch<T>(string? route, object? body)
        {
            if (string.IsNullOrEmpty(route)) route = string.Empty;
            var request = this.SetRequest(route);
            if (body != null) request.AddJsonBody(body);

            var response = await this.Client.PatchAsync<T>(request);
#nullable disable warnings
            return response;
#nullable restore warnings
        }

        public async Task<T> Delete<T>(string? route)
        {
            if (string.IsNullOrEmpty(route)) route = string.Empty;

            var request = this.SetRequest(route);

            var response = await this.Client.DeleteAsync<T>(request);
#nullable disable warnings
            return response;
#nullable restore warnings
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.Client.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
