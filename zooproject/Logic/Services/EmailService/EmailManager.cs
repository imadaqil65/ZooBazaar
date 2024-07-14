using BarcodeStandard;
using Infrastructure.Email;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.EmailService
{
	public class EmailManager
	{
		IEmail datasource;
		private List<MemoryStream> attachments;
		public EmailManager(IEmail datasource)
		{
			this.datasource = datasource;
			attachments = new List<MemoryStream>();
		}

		public void SendEmail(string email, string subject, string message)
		{
			datasource.SendEmailAsync(email, subject, message, attachments).Wait();
		}
		public void AddAttachment(MemoryStream stream, string fileName)
		{
			attachments.Add(stream);
		}
	}
}
