namespace SoundScape.Models.ResponseModel
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string Menssage { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
