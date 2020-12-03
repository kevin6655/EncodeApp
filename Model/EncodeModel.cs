using System;
using System.Collections.Generic;
using System.Text;
using Base64UrlCore;
using System.Web;

namespace TodoApp.Model
{
    class EncodeModel : IEncoding
    {
        
        public string Base64EncordString(string _inputtext)
        {
            try
            {
                return String.IsNullOrEmpty(_inputtext) ? "値が入力されていません。" : Base64Url.Encode(_inputtext);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string Utf8EncordString(string _inputtext)
        {
            try
            {
                // URLエンコード
                return String.IsNullOrEmpty(_inputtext) ? "値が入力されていません。" : Uri.EscapeDataString(_inputtext);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
