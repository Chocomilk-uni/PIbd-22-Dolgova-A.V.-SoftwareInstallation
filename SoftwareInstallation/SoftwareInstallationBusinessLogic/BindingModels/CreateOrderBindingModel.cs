namespace SoftwareInstallationBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int PackageId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}