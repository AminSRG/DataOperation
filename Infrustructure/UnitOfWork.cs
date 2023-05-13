using Infrustructure.AnyModel;
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
        public IAnyModelRepository _anyModelRepository { get; set; }

        public UnitOfWork(IAnyModelRepository anyModelRepository)
        {
            _anyModelRepository = anyModelRepository;
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
