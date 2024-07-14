using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
	public class dbEmail : IEmail
	{
		public Task SendEmailAsync(string email, string subject, string message, List<MemoryStream> attachments)
		{
			var client = new SmtpClient("smtp-mail.outlook.com", 587)
			{
				EnableSsl = true,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("project_group78@hotmail.com", "group3fontys")
			};

			var mailMessage = new MailMessage("project_group78@hotmail.com", email, subject, message);
			foreach (var attachment in attachments)
			{
				var attachmentStream = new MemoryStream(attachment.ToArray());
				attachmentStream.Position = 0; // Reset the position of the new MemoryStream to the beginning

				mailMessage.Attachments.Add(new Attachment(attachmentStream, "barcode.png"));
			}

			return client.SendMailAsync(mailMessage);
		}

	}
}
