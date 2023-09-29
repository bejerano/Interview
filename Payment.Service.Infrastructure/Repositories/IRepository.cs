using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.Infrastructure.Repositories;

public interface IRepository<T> where T : PlootoEntity, new()
{
    IUnitOfWork UnitOfWork { get; }
   
}