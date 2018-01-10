using Dapper;

namespace Neptune.Services.Common.Data
{
    public interface IDataRecord<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class BaseData<TKey> : IDataRecord<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
