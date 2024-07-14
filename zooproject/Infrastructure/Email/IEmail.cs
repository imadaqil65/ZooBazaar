﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
	public interface IEmail
	{
		Task SendEmailAsync(string email, string subject, string message, List<MemoryStream> attachements);
	}
}
