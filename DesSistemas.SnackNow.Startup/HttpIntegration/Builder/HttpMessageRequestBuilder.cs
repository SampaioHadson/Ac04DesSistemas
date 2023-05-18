using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;
using Newtonsoft.Json;
using System.Text;

namespace DesSistemas.SnackNow.Startup.HttpIntegration.Builder
{
    public class HttpMessageRequestBuilder
    {
        private readonly HttpMessageRequestDto _request;

        public HttpMessageRequestBuilder() 
        { 
            _request = new HttpMessageRequestDto();
        }

        public HttpMessageRequestBuilder Post()
        {
            _request.Method = Enum.HttpMessageRequestMethod.POST;
            return this;
        }

        public HttpMessageRequestBuilder Get()
        {
            _request.Method = Enum.HttpMessageRequestMethod.GET;
            return this;
        }

        public HttpMessageRequestBuilder Put()
        {
            _request.Method = Enum.HttpMessageRequestMethod.PUT;
            return this;
        }

        public HttpMessageRequestBuilder Patch()
        {
            _request.Method = Enum.HttpMessageRequestMethod.PATCH;
            return this;
        }

        public HttpMessageRequestBuilder Delete()
        {
            _request.Method = Enum.HttpMessageRequestMethod.DELETE;
            return this;
        }

        public HttpMessageRequestBuilder WithUrl(string url)
        {
            _request.Url = url;
            return this;
        }

        public HttpMessageRequestBuilder WithHeader(string key, string value)
        {
            _request.Headers ??= new Dictionary<string, string>();

            if (_request.Headers.ContainsKey(key))
                _request.Headers.Remove(key);

            _request.Headers.Add(key, value);
            return this;
        }

        public HttpMessageRequestBuilder WithParam(string key, string value)
        {
            _request.QueryParams ??= new Dictionary<string, string>();

            if (_request.QueryParams.ContainsKey(key))
                _request.QueryParams.Remove(key);

            _request.QueryParams.Add(key, value);
            return this;
        }

        public HttpMessageRequestBuilder WithFormUrlEncodedContent(Dictionary<string, string> form)
        {
            _request.Content = new FormUrlEncodedContent(form);
            return this;
        }

        public HttpMessageRequestBuilder WithJsonBody(object body)
        {
            var stringBody = JsonConvert.SerializeObject(body);
            _request.Content = new StringContent(stringBody, Encoding.UTF8, "application/json");
            return this;
        }

        public HttpMessageRequestDto Build()
        {
            Validate();
            BindQueryParams();
            return _request;
        }

        private void Validate()
        {
            Guard.Guard.NullOrEmpty(_request.Url, () => new HttpInternalServerErrorException("Url inválida"));
        }

        private void BindQueryParams()
        {
            if (_request.QueryParams is null)
                return;                

            var urlBuilder = new StringBuilder(_request.Url);
            urlBuilder.Append('?');

            var last = urlBuilder.Length - 1;
            var index = 0;
            foreach ( var param in _request.QueryParams)
            {
                urlBuilder.Append(param.Key);
                urlBuilder.Append('=');
                urlBuilder.Append(param.Value);

                if(index != last)
                    urlBuilder.Append('&');
                
                index++;
            }
  
            _request.Url = urlBuilder.ToString();
        }
    }
}