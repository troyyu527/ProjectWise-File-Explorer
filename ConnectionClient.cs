using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWiseApp
{
    public class ConnectClientAPI_MSIL
    {
        private object _instance = null;

        public ConnectClientAPI_MSIL()
        {
            try
            {
                // should be correct bit-wise

                string sPath = @"C:\Program Files\Bentley\ProjectWise\bin";
                // should get the one of the right bitness...
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(Path.Combine(sPath, "Bentley.Connect.Client.API.dll"));

                _instance = assembly.CreateInstance("Bentley.Connect.Client.API.V1.ConnectClientAPI");
                // Bentley.Connect.Client.API.V1
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
                throw ex;
            }
        }

        public string GetBuddiUrl(string sUrlCode)
        {
            if (_instance != null)
            {
                // Bentley.Connect.Client.API.V1.ConnectClientAPI conn = new Bentley.Connect.Client.API.V1.ConnectClientAPI();

                // conn.GetBuddiUrl()
                // conn.GetDefaultUsername()
                // conn.IsLoggedIn()
                // conn.GetSerializedDelegateSecurityToken()

                try
                {
                    object[] argstopass = new object[] { (object)sUrlCode };

                    string sReturnValue = (string)_instance
                        .GetType() //Get the type of _instance
                        .GetMethod("GetBuddiUrl", new[] { typeof(string) }) // Gets a System.Reflection.MethodInfo object representing GetBuddiUrl(string) rather than GetBUddiUrl(string, int)
                        .Invoke(_instance, argstopass); //here we invoke SomeMethod. We also pass ArgsToPass as the argument list

                    return sReturnValue;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
                }
            }

            return string.Empty;
        }

        public string GetDefaultUsername()
        {
            if (_instance != null)
            {
                try
                {
                    string sReturnValue = (string)_instance
                        .GetType() //Get the type of MyDLLForm
                        .GetMethod("GetDefaultUsername") //Gets a System.Reflection.MethodInfo object representing Some
                        .Invoke(_instance, null); //here we invoke SomeMethod. We also pass ArgsToPass as the argument list

                    return sReturnValue;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
                }
            }

            return string.Empty;
        }
        public string GetSerializedDelegateSecurityToken(string sRelyingParty)
        {
            if (_instance != null)
            {
                try
                {
                    object[] argstopass = new object[] { (object)sRelyingParty };

                    string sReturnValue = (string)_instance
                        .GetType() //Get the type of MyDLLForm
                        .GetMethod("GetSerializedDelegateSecurityToken") //Gets a System.Reflection.MethodInfo object representing Some
                        .Invoke(_instance, argstopass); //here we invoke SomeMethod. We also pass ArgsToPass as the argument list

                    return sReturnValue;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
                }
            }

            return string.Empty;
        }

        public bool IsLoggedIn()
        {
            if (_instance != null)
            {
                try
                {
                    bool bReturnValue = (bool)_instance
                        .GetType() //Get the type of MyDLLForm
                        .GetMethod("IsLoggedIn") //Gets a System.Reflection.MethodInfo object representing Some
                        .Invoke(_instance, null); //here we invoke SomeMethod. We also pass ArgsToPass as the argument list

                    return bReturnValue;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
                }
            }

            return false;
        }
    }
}
