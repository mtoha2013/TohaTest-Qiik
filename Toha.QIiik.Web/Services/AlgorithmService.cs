using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;
using Toha.QIiik.Web.Models;

namespace Toha.QIiik.Web.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        public AlgorithmResponse HashMe(string stringInput)
        {
            AlgorithmResponse oResult = new AlgorithmResponse() { Algorithm = "MD5", Value = "" };

            //using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            //{
            //    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(stringInput);
            //    byte[] hashBytes = md5.ComputeHash(inputBytes);

            //    StringBuilder sb = new System.Text.StringBuilder();
            //    for (int i = 0; i < hashBytes.Length; i++)
            //    {
            //        sb.Append(hashBytes[i].ToString("X2"));
            //    }
            //    oResult.Value = sb.ToString();
            //}

            //MD5 md5 = new MD5CryptoServiceProvider();

            ////compute hash from the bytes of text  
            //md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(stringInput));


            ////get hash result after compute it  
            //byte[] result = md5.Hash;

            //StringBuilder strBuilder = new StringBuilder();
            //for (int i = 0; i < result.Length; i++)
            //{
            //    //change it into 2 hexadecimal digits  
            //    //for each byte  
            //    strBuilder.Append(result[i].ToString("x2"));
            //}

            //oResult.Value = strBuilder.ToString();


            //using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            //{
            //    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(stringInput);
            //    byte[] hashBytes = md5.ComputeHash(inputBytes);

            //    StringBuilder sb = new StringBuilder();
            //    for (int i = 0; i < hashBytes.Length; i++)
            //    {
            //        sb.Append(hashBytes[i].ToString("X2"));
            //    }
            //    oResult.Value = sb.ToString();
            //}


            byte[] valueBytes = new byte[stringInput.Length]; // <-- don't multiply by 2!

            Encoder encoder = Encoding.UTF8.GetEncoder(); // <-- UTF8 here
            encoder.GetBytes(stringInput.ToCharArray(), 0, stringInput.Length, valueBytes, 0, true);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(valueBytes);

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2"));
            }

            oResult.Value = stringBuilder.ToString();

            return oResult;
        }
    }
}
