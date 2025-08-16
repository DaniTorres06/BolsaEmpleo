namespace BolsaEmpleoModel.Response
{
    public class RspGeneric<T>
    {
        public T DataGeneric { get; set; }
        public Response? Response { get; set; }

        public RspGeneric()
        {
            DataGeneric = default;
            Response = new Response();
        }
    }
}
