using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using groupePjvApp.ViewModels;
using groupePjvApp.Models;

namespace groupePjvApp.Models
{
    public class Utilitaires
    {
        public Utilitaires()
        {

        }

        public byte[] convertir(string chemin)
        {
            Image img = Image.FromFile(chemin);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                arr = ms.ToArray();
            }
            return arr;
        }

        public bool EnvoyerCourriel(string sujet, string message, Representant rep)
        {
            MailMessage email = new MailMessage();
            email.From = new System.Net.Mail.MailAddress(rep.Courriel);
            email.To.Add(new MailAddress(System.Configuration.ConfigurationManager.AppSettings["courrielPjv"]));
            email.IsBodyHtml = true;

            email.Subject = sujet;
            email.Body = message;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["host"];
            smtp.Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["port"]);
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("lacpat01@gmail.com", "Tableau1!");
            try
            {
                smtp.Send(email);
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
    }
}