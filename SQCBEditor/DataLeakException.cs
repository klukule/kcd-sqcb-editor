using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQCBEditor
{
    /// <summary>
    /// Caused when something is wrong :)
    /// </summary>
    /// <seealso cref="System.Exception" />
    public sealed class DataLeakException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLeakException"/> class.
        /// </summary>
        public DataLeakException() : base("Data leak")
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLeakException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DataLeakException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLeakException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public DataLeakException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
