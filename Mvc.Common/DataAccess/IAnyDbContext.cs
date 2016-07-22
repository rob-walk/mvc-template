using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mvc.Common.Domain;

namespace Mvc.Common.DataAccess
{
    public interface IAnyDbContext
    {        
        IDbSet<Eventlog> Eventlogs { get; set; }
        IDbSet<T> EntitieSet<T>() where T : Entity;
        DbEntityEntry GetEntry(object entity);
        void Save();
    }
}
