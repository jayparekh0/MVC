using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Utility
{
    public class Utility
    {
    }
    public sealed class ErrorSave
    {
        private ErrorSave() { }
        private static ErrorSave _errSaveObj = null;
        private static readonly object obj = new object();
        public static ErrorSave _getInstance
        {
            get
            {
                if (_errSaveObj == null)
                {
                    lock (obj)
                    {
                        _errSaveObj = new ErrorSave();
                    }
                }
                return _errSaveObj;
            }
        }
        public void Log(object error)
        {

        }
    }
}