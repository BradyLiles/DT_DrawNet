using System;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace DrawNet.Lib.Core.Services.Email
{
    public class EmailService
    {
        public EmailService()
        {
            
        }

        
        public static string RenderPartialViewToString<T>( string fullTemplatePath, string templateName, T model )
        {
            string templateSource = File.ReadAllText( fullTemplatePath );
//            Engine.Razor.AddTemplate( "TemplateAlias", File.ReadAllText(ViewPath + "_Layout.cshtml" ));
            return Engine.Razor.RunCompile( templateSource, templateName, typeof(T), model );
        }

        public static string PasswordResetEmail( Logic.Email.Templates.Account.ResetPassword passwordResetEmail)
        {
            return RenderPartialViewToString(Path.Combine( ExecutionDirectoryPathName, "Email/Templates/Account/" ) + "ResetPassword.cshtml", "TemplateAlias", passwordResetEmail );
        }

        public static string ExecutionDirectoryPathName => Path.GetDirectoryName(new System.Uri( Assembly.GetExecutingAssembly().CodeBase ).AbsolutePath);
        public static string ViewPath => Path.Combine(ExecutionDirectoryPathName, "Email/Templates/" );
    }


}