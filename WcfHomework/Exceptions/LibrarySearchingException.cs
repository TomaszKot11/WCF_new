using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfHomework.Exceptions
{
    [DataContract]
    class LibrarySearchingException
    {
        [DataMember]
        public string CustomMessage;

        [DataMember]
        public string OperationType;

    }
}
