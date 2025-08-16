namespace BolsaEmpleoModel.Response
{
    public class RspListGeneric<T>
    {
        public List<T> DataList { get; set; }
        public Response? Response { get; set; }

        public RspListGeneric()
        {
            DataList = new List<T>();
            Response = new Response();
        }
    }
}
