namespace BolsaEmpleoModel.Response
{
    public class Response
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public Response()
        {
            Message = string.Empty;
            Status = false;
        }
    }
}
