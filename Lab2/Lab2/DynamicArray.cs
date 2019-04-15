using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2
{
    public class DynamicArray<T>: IDisposable, IEnumerable<T> where T:new()
    {
        private T[] _Items;

        public T this[int index]
        {
            get
            {
                return _Items[index];
            }
            set
            {
                _Items[index] = value;
            }
        }

        #region Constructors       
        public DynamicArray (int size)
        {
            _Items = new T[size];
            Console.WriteLine($"Creating DynamicArray from thread " +
                $"{Thread.CurrentThread.ManagedThreadId}");
        }

        public DynamicArray (IEnumerable<T> items)
        {
            _Items = items.ToArray();
            Console.WriteLine($"Creating DynamicArray from thread " +
                $"{Thread.CurrentThread.ManagedThreadId}");
        }

        #endregion Constructors

        public void Resize(int newSize)
        {
            T[] items = new T[newSize];

            for (int i = 0; i< newSize; ++i)
            {
                items[i] = new T();
            }

            int lessLength = newSize < _Items.Length ? newSize : _Items.Length; //make sure not to exeed index for _Items or items

            for (int i = 0; i < lessLength; ++i)
            {
                items[i] = _Items[i];
            }

            _Items = items;
        }

        #region IDisposable Support
        private bool _Disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    _Items = null;
                }

                // No unmanaged memory to free, skip this step

               _Disposed = true;
            }
        }

     
        ~DynamicArray() {
            Console.WriteLine($"Finalizing DynamicArray from thread " +
                $"{Thread.CurrentThread.ManagedThreadId}");
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {

            Console.WriteLine($"Disposing DynamicArray from thread " +
                $"{Thread.CurrentThread.ManagedThreadId}");
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
           
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable Support

        #region IEnumerator<T> Interface
        public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }
        #endregion IEnumerator<T> Interface

    }
}
