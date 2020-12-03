using System;
using System.Collections.Generic;
using System.Text;

namespace EncodeApp.Model
{
    public interface IEncoding
    {
        public string Base64EncordString(string _inputtext);
        public string Utf8EncordString(string _inputtext);
    }
}
