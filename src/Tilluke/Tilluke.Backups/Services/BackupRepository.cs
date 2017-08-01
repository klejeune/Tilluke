using System.Collections.Generic;
using System.Linq;
using Tilluke.Backups.Models;

namespace Tilluke.Backups.Services
{
    public class BackupRepository
    {
        private readonly IDictionary<string, Backup> backups = new Dictionary<string, Backup>();

        public void Save(Backup backup)
        {
            this.backups[backup.Id] = backup;
        }

        public IQueryable<Backup> Get()
        {
            return this.backups.Values.AsQueryable();
        }
    }
}