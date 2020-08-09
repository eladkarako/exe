using System;
using System.Diagnostics;
using System.Security;

namespace exe{
  class Program{

    public static String value_or_null(string[] array, uint index){ //normalize out-of-bound/empty to null. and value otherwize.
      String value = null;
      try {
        value = array[index];
      }catch (IndexOutOfRangeException){}
      return value;
    }
    
    public static void Main(string[] args){
      Process process = new Process();
      
      String filename          = value_or_null(args,0);
      String arguments         = value_or_null(args,1);
      String working_directory = value_or_null(args,2);
      String verb              = value_or_null(args,3);
      String window_style      = value_or_null(args,4);
      String is_load_profile   = value_or_null(args,5);
      String domain            = value_or_null(args,6);
      String username          = value_or_null(args,7);
      String password          = value_or_null(args,8);

/*    //only useful for debugging when the application is in "console-mode" (see project properties- Project/PropertyGroup/OutputType: "Exe" to "WinExe" meaning no console mode).
      Console.Error.WriteLine(String.Join("\r\n", new String[]{
        "----=[RAW VALUES]=-------------------------------------"
       ,"0. filename:           " + ">" + filename          + "<"
       ,"1. arguments:          " + ">" + arguments         + "<"
       ,"2. working_directory:  " + ">" + working_directory + "<"
       ,"3. verb:               " + ">" + verb              + "<"
       ,"4. window_style:       " + ">" + window_style      + "<"
       ,"5. is_load_profile:    " + ">" + is_load_profile   + "<"
       ,"6. domain:             " + ">" + domain            + "<"
       ,"7. username:           " + ">" + username          + "<"
       ,"8. password:           " + ">" + password          + "<"
       ,"-------------------------------------------------------"
      }));
*/
      process.StartInfo.UseShellExecute = true;
      process.StartInfo.ErrorDialog = false;
      process.StartInfo.ErrorDialogParentHandle = IntPtr.Zero;
      process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;  //default.
      process.StartInfo.LoadUserProfile = false;                  //default
      
      if(filename          != null)  process.StartInfo.FileName          = filename;
      if(arguments         != null)  process.StartInfo.Arguments         = arguments;
      if(working_directory != null)  process.StartInfo.WorkingDirectory  = working_directory;
      if(verb              != null)  process.StartInfo.Verb              = verb;
      if(window_style      != null){                              //possible override for default.
             if(window_style.Equals("normal",   StringComparison.CurrentCultureIgnoreCase) == true)  process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        else if(window_style.Equals("minimized",StringComparison.CurrentCultureIgnoreCase) == true)  process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
        else if(window_style.Equals("maximized",StringComparison.CurrentCultureIgnoreCase) == true)  process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        else if(window_style.Equals("hidden",   StringComparison.CurrentCultureIgnoreCase) == true)  process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      }
      if(is_load_profile   != null)  process.StartInfo.LoadUserProfile   = (is_load_profile.Equals("true",StringComparison.CurrentCultureIgnoreCase) == true);   //possible override for default.
      if(domain            != null)  process.StartInfo.Domain            = domain;
      if(username          != null)  process.StartInfo.UserName          = username;
      if(password          != null){
        SecureString secure_string = new SecureString();
        char[] chars_password      = password.ToCharArray();
        foreach (char c in chars_password) secure_string.AppendChar(c);
        process.StartInfo.Password = secure_string;
      }
      
      
      try{
        process.Start();
      }catch(Exception){}
   }
  }
}