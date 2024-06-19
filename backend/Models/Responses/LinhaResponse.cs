namespace purrfect_olho_vivo_api.ViewModels.Responses
{
    public class LinhaResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ParadaResponse> Paradas { get; set; }
    }
}