namespace Books.Core
{
    public class Const
    {
        static string? _API_URL = null;
        public static string API_URL
        {
            get
            {
                if (_API_URL == null)
                {
                    _API_URL = "https://fakerestapi.azurewebsites.net";
                }
                return _API_URL;
            }
        }
    }
}
