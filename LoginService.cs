	using System;
	using System.Collections.Generic;
	 
	namespace App.Services
	{
	    public enum LoginResult
	    {
	        Unknown = 0,
	        Success = 1,
	        WrongLogin = -1,
	        WrongPass = -2,
	        Error
	    }
	 
	    public class LoginService
	    {
	        public string LastError = string.Empty;
	 
	        /// <summary>
	        /// Allow to login new user
	        /// </summary>
	        /// <param name="login">login</param>
	        /// <param name="password">password</param>
	        /// <param name="asAdmin">asAdmin</param>
	        /// <returns>login result</returns>
	        public LoginResult Login(string login, string password)
	        {
	            List<Login> dbLogins = new List<Login>();
		    var log = System.IO.File.AppendText(App.LogFile);
	            try
	            {
	                dbLogins.AddRange(
	                    DAL.GetItems<Login>(
	                    "select * from db.Login where Name='" + login + "'"));
	            }
	            catch (Exception ex)
	            {
	                lock ((object)777)
	                {
	                    LastError = ex.Message;
	                }
	                throw ex;
	            }
                    finally 
		    {
                        log.WriteLine("Error occurred");
                    }
                
	            if (dbLogins.Count < 1)
	            {
	                return LoginResult.WrongLogin;
	            }
	 
	            var prevUser = App.CurrentUser;
	            App.CurrentUser = dbLogins[0];
	            if (password.CompareTo(App.CurrentUser.Password) != 0)
	            {
	                App.CurrentUser = prevUser;
	                return LoginResult.WrongPass;
	            }
	 
	            
	            log.WriteLine("New user loggined. Login=" + App.CurrentUser.Name);
	 
	            if (!(bool)((EventService)App.Service).SendWithConfirm(prevUser))
	            {
	                log.Write("Error sending to user.");
	            }
          
	            GC.Collect();
	            GC.Collect();

	            return LoginResult.Success;
	        }
	    }
	}
