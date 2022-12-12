using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    internal interface ISerialiser
    {
        void Serialise<T>(T item, string toPath);
        T Deserialise<T>(string fromPath);
    }
}
