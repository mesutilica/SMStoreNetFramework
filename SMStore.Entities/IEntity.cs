namespace SMStore.Entities
{
    public interface IEntity
    {
        int Id { get; set; } // klasik .net frameworkde interface property leri erişim belirteci kabul etmiyor!
    }
}
