using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace Cir.Common.Utilities {
	public class Mail {

		public static MemoryStream GenerateEml(MailMessage message) {

			Assembly assembly = typeof(SmtpClient).Assembly;
			Type mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");

			var stream = new MemoryStream();

			// Get reflection info for MailWriter contructor
			ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(
				BindingFlags.Instance | BindingFlags.NonPublic,
				null,
				new Type[] { typeof(Stream) },
				null);

			// Construct MailWriter object with our stream
			object mailWriter = mailWriterContructor.Invoke(new object[] { stream });

			// Get reflection info for Send() method on MailMessage
			MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);

			// Call method passing in MailWriter
			sendMethod.Invoke(
				message,
				BindingFlags.Instance | BindingFlags.NonPublic,
				null,
				new object[] { mailWriter, true },
				null);

			// Finally get reflection info for Close() method on our MailWriter
			MethodInfo closeMethod = mailWriter.GetType().GetMethod(
				"Close",
				BindingFlags.Instance | BindingFlags.NonPublic);

			// Call close method
			closeMethod.Invoke(
				mailWriter,
				BindingFlags.Instance | BindingFlags.NonPublic,
				null,
				new object[] { },
				null);

			return new MemoryStream(stream.ToArray());
		}

	    /// <summary>
	    /// Send an email using techcim@vestas.com as the default "from" value
	    ///     Check for SMTP Exceptions on the caller
	    /// </summary>
	    /// <param name="to"></param>
	    /// <param name="title"></param>
	    /// <param name="body"></param>
        /// <param name="smtpServer">usually Environment.SMTPHost</param>	    
	    public void SendEmail(string to, string title, string body, string smtpServer)
        {
            const string @from = "TechCIR@vestas.com";            

            var mailObj = new MailMessage(from, to, title, body) {IsBodyHtml = true};
            var smtp = new SmtpClient(smtpServer) { UseDefaultCredentials = true };

            // send mail
            smtp.Send(mailObj);
        }
	}
}
