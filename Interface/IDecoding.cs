using System;
using System.Collections.Generic;
using System.Text;

namespace EncodeApp.Model
{
    public interface IDecoding
    {
        public string Base64DecordString(string _inputtext);
        public string Utf8DecordString(string _inputtext);
    }
}
