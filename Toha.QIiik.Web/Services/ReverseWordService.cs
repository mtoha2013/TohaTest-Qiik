using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;

namespace Toha.QIiik.Web.Services
{
    public class ReverseWordService : IReverseWordService
    {
        public string ReverseWord(string value)
        {
            string sResult = "";
            for (int i = 0; i < value.Length; i++)
            {
                int indexNow = (value.Length -1) - i;
                sResult = sResult + value[indexNow];
            }

            return sResult;
        }
    }
}
