using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DrawNet.Lib.Core.Utilities
{
    public static class Emailer
    {
        public static async Task<bool> SendEmail(MailAddress onBehalfOf, List<string> toAddress, List<string> ccAddress, List<string> bccAddress, string subject, string htmlBody, string plainBody = null, List<string> attachments = null, bool ignoreError = false)
        {
            SmtpClient smtpClient = new SmtpClient { };

            MailMessage message = new MailMessage();
            try
            {
                message.From = new MailAddress(Common.Email.Email_Default);
                toAddress?.ForEach(address => message.To.Add(address));
                ccAddress?.ForEach(address => message.CC.Add(address));
                bccAddress?.ForEach(address => message.Bcc.Add(address));

                message.Subject = subject?.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");

                if (onBehalfOf != null)
                {
                    message.ReplyToList.Add(onBehalfOf.Address);
                    message.From = onBehalfOf;
                }

                if (plainBody != null)
                {
                    message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(plainBody, System.Text.Encoding.UTF8, MediaTypeNames.Text.Plain));
                }

                if (htmlBody != null)
                {
                    message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(htmlBody, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html));
                }

                attachments?.ForEach(attachment =>
                {
                    if (File.Exists(attachment))
                    {
                        Attachment data = new Attachment(attachment, MediaTypeNames.Application.Octet);

                        ContentDisposition disposition = data.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(attachment);
                        disposition.ModificationDate = File.GetLastWriteTime(attachment);
                        disposition.ReadDate = File.GetLastAccessTime(attachment);
                        message.Attachments.Add(data);
                    }
                });

                await Task.Run(() => smtpClient.Send(message));
                message.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                if (ignoreError == false)
                {
                    string errorMessage = "Error sending email";
                    errorMessage += "\n" + "To: ";
                    errorMessage = toAddress?.Aggregate(errorMessage, (current, address) => current + address);
                    errorMessage += "\n" + "CC: ";
                    errorMessage = ccAddress?.Aggregate(errorMessage, (current, address) => current + address);
                    errorMessage += "\n" + "Bcc: ";
                    errorMessage = bccAddress?.Aggregate(errorMessage, (current, address) => current + address);
                    errorMessage += "\n" + "Subject: " + subject;
                    errorMessage += "\n\n" + "HtmlBody: " + htmlBody;
                    errorMessage += "\n\n" + "PlainBody: " + plainBody;
                    errorMessage += "\n\n" + "Error: " + ex.Message;
                    throw new Exception(errorMessage);
                }

                return false;
            }
        }
    }
}
