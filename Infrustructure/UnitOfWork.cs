using Infrustructure.DataExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool IsDisposed { get; set; }
        public IDataExampleRepository _DataExampleRepository { get; set; }

        public UnitOfWork(IDataExampleRepository DataExampleRepository)
        {
            _DataExampleRepository = DataExampleRepository;
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
        /// </summary>
        public void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {

            }


            IsDisposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
