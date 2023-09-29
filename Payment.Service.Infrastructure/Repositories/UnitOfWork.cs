// using Plooto.Assessment.Payment.Infrastructure.Repositories;

// namespace Plooto.Assessment.Payment.Infrastructure;

// public class UnitOfWork : IUnitOfWork, IDisposable
// {
//      private readonly PaymentContext _context;
//     private bool _disposed;
//     public UnitOfWork(PaymentContext context)
//     {
//         _context = context;
//     }
//     public void Commit()
//     {
//         _context.SaveChanges();
//     }
//     public void Rollback()
//     {
//         foreach (var entry in _context.ChangeTracker.Entries())
//         {
//             switch (entry.State)
//             {
//                 case EntityState.Added:
//                     entry.State = EntityState.Detached;
//                     break;
//             }
//         }
//     }
//     public IRepository<T> Repository<T>() where T : PlootoEntity, new()
//     {
//         return new Repository<T>(_context);
//     }


    
// }
