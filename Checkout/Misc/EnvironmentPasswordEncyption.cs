using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Security.Cryptography;

namespace Checkout
{
    public class EnvironmentPasswordEncyption
    {
        /// <summary>
        /// 
        /// </summary>
        public string LastError = "";
        /// <summary>
        /// 
        /// </summary>
        public bool ErrorHit
        {
            get { return (LastError.Trim() != ""); }
        }

        TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

        /// <summary>
        /// 
        /// </summary>
        public EnvironmentPasswordEncyption()
        {
        }

        /// <summary>
        /// Sets up the object with an initial key/vector.
        /// Expects parameters to be in byte string format
        /// i.e. -bytevalue-bytevalue...
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Vector"></param>
        public EnvironmentPasswordEncyption(string Key, string Vector)
        {
            try
            {
                SetPWDKey(Key);
                SetIV(Vector);
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
            }
        }


        /// <summary>
        /// Converts a string into its byte string (format "-123-98"..)
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public string ConvertStringToByteString(string Target)
        {
            string tmp = Target.Trim();
            ArrayList A = new ArrayList();
            for (int I = 0; I < tmp.Length; I++)
            {
                A.Add(Convert.ToByte(tmp[I]));
            }
            tmp = "";
            for (int I = 0; I < A.Count; I++)
            {
                tmp = tmp + "-" + A[I].ToString();
            }
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPWDKey()
        {
            string tmp = "";
            for (int I = 0; I < TDES.Key.Length; I++)
            {
                tmp += "-" + TDES.Key[I];
            }
            return tmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PWDKey"></param>
        public void SetPWDKey(string PWDKey)
        {

            ArrayList A = new ArrayList();
            string[] S = PWDKey.Split('-');
            for (int I = 0; I < S.Length; I++)
            {
                S[I] = S[I].Replace("-", "");
                if (S[I] != "")
                    A.Add(Convert.ToByte(S[I]));
            }

            //Convert the passed string to a byte array.
            byte[] ByteString = (byte[])A.ToArray(Type.GetType("System.Byte"));
            try
            {
                TDES.Key = ByteString;
            }
            catch
            {
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetIV()
        {
            string tmp = "";
            for (int I = 0; I < TDES.IV.Length; I++)
            {
                tmp += "-" + TDES.IV[I];
            }
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IVstring"></param>
        public void SetIV(string IVstring)
        {
            ArrayList A = new ArrayList();
            string[] S = IVstring.Split('-');
            for (int I = 0; I < S.Length; I++)
            {
                S[I] = S[I].Replace("-", "");
                if (S[I] != "")
                    A.Add(Convert.ToByte(S[I]));
            }

            //Convert the passed string to a byte array.
            byte[] ByteString = (byte[])A.ToArray(Type.GetType("System.Byte"));

            TDES.IV = ByteString;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetKeySize()
        {
            return TDES.Key.Length.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetVectorSize()
        {
            return TDES.IV.Length.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CurrentEncryptionLength()
        {
            return TDES.KeySize.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sz"></param>
        /// <param name="Msg"></param>
        public void SetCurrentEncryptionLength(int Sz, ref string Msg)
        {
            ClearErrors();
            Msg = "";
            try
            {
                TDES.KeySize = Sz;
                TDES.GenerateIV();
                TDES.GenerateKey();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                LastError = Msg;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public string EncryptPassword(string Data, ref string Msg)
        {
            try
            {
                ClearErrors();
                Msg = "";
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(TDES.Key, TDES.IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                string EncodedString = "";

                //Convert the byte array to a string representation
                for (int I = 0; I < ret.Length; I++)
                {
                    EncodedString = EncodedString + (char)ret[I];
                }

                //Convert the string representation to a byte string representation
                //This must be done so that we can store the information without
                //having SQL server change the value on us (unrecognized characters
                //get changed by SQL server to a "?" value for varchar)
                EncodedString = ConvertStringToByteString(EncodedString);

                // Return the encrypted buffer.
                return EncodedString;
            }
            catch (CryptographicException e)
            {
                Msg = e.Message;
                LastError = Msg;
                return "";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string EncryptPassword(string Data)
        {
            try
            {
                ClearErrors();
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(TDES.Key, TDES.IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                string EncodedString = "";

                //Convert the byte array to a string representation
                for (int I = 0; I < ret.Length; I++)
                {
                    EncodedString = EncodedString + (char)ret[I];
                }

                //Convert the string representation to a byte string representation
                //This must be done so that we can store the information without
                //having SQL server change the value on us (unrecognized characters
                //get changed by SQL server to a "?" value for varchar)
                EncodedString = ConvertStringToByteString(EncodedString);

                // Return the encrypted buffer.
                return EncodedString;
            }
            catch (CryptographicException e)
            {
                LastError = e.Message;
                return "";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncryptedPW"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public string DecryptPassword(string EncryptedPW, ref string Msg)
        {
            ClearErrors();
            Msg = "";
            try
            {
                if (!EncryptedPW.StartsWith("-"))
                {
                    EncryptedPW = ConvertStringToByteString(EncryptedPW);

                    //// Replace the "?" with the box character.  This
                    //// is due to the fact that SQL Server will change
                    //// the physical string stored as it is storing it
                    ////
                    ////This may NOT be the only example of the problem
                    ////
                    //EncryptedPW = EncryptedPW.Replace("-63-", "-150-");
                    //EncryptedPW = EncryptedPW.Replace("-63", "-150");  //check for ending 63
                }

                ArrayList A = new ArrayList();
                string[] S = EncryptedPW.Split('-');
                for (int I = 0; I < S.Length; I++)
                {
                    S[I] = S[I].Replace("-", "");
                    if (S[I] != "")
                        A.Add(System.Convert.ToByte(S[I]));
                }

                //Convert the passed string to a byte array.
                byte[] Data = (byte[])A.ToArray(System.Type.GetType("System.Byte"));

                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(TDES.Key, TDES.IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                string RetString = new ASCIIEncoding().GetString(fromEncrypt);

                //Remove any extra '0's at the end
                RetString = RetString.Replace("\0", "");
                return RetString;
            }
            catch (CryptographicException e)
            {
                Msg = e.Message;
                LastError = Msg;
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncryptedPW"></param>
        /// <returns></returns>
        public string DecryptPassword(string EncryptedPW)
        {
            ClearErrors();
            try
            {
                if (!EncryptedPW.StartsWith("-"))
                {
                    EncryptedPW = ConvertStringToByteString(EncryptedPW);

                    //// Replace the "?" with the box character.  This
                    //// is due to the fact that SQL Server will change
                    //// the physical string stored as it is storing it
                    ////
                    ////This may NOT be the only example of the problem
                    ////
                    //EncryptedPW = EncryptedPW.Replace("-63-", "-150-");
                    //EncryptedPW = EncryptedPW.Replace("-63", "-150");  //check for ending 63
                }

                ArrayList A = new ArrayList();
                string[] S = EncryptedPW.Split('-');
                for (int I = 0; I < S.Length; I++)
                {
                    S[I] = S[I].Replace("-", "");
                    if (S[I] != "")
                        A.Add(System.Convert.ToByte(S[I]));
                }

                //Convert the passed string to a byte array.
                byte[] Data = (byte[])A.ToArray(Type.GetType("System.Byte"));

                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(TDES.Key, TDES.IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                string RetString = new ASCIIEncoding().GetString(fromEncrypt);

                //Remove any extra '0's at the end
                RetString = RetString.Replace("\0", "");
                return RetString;
            }
            catch (CryptographicException e)
            {
                LastError = e.Message;
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearErrors()
        {
            LastError = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncryptedPassword"></param>
        /// <param name="EnteredPassword"></param>
        /// <returns></returns>
        public bool PasswordsMatch(string EncryptedPassword, string EnteredPassword)
        {
            bool PWMatch = false;
            //Decrypt the encoded password
            ClearErrors();
            string Pwd = DecryptPassword(EncryptedPassword, ref LastError);
            if (LastError == "")
            {
                if (Pwd == EnteredPassword)
                {
                    PWMatch = true;
                }
            }
            return PWMatch;
        }
    }
}
