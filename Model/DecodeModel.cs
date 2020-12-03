using System;
using System.Collections.Generic;
using System.Text;
using Base64UrlCore;
using System.Web;

namespace TodoApp.Model
{
    class DecodeModel:IDecoding
    {
        public string Base64DecordString(string _inputtext)
        {
            try
            {
                return String.IsNullOrEmpty(_inputtext) ? "値が入力されていません。" : Base64Url.Decode(_inputtext);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string Utf8DecordString(string _inputtext)
        {
            try
            {
                //URLデコード
                return String.IsNullOrEmpty(_inputtext) ? "値が入力されていません。" : HttpUtility.UrlDecode(_inputtext);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
