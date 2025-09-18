using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Simulera mail (logga till konsolen eller ignorera)
            Console.WriteLine($"Email to: {email}, Subject: {subject}, Body: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}
