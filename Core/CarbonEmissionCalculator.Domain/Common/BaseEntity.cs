namespace CarbonEmissionCalculator.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string FirmName { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
