using UnityEngine;

//for email with smtp
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class EmailSender : MonoBehaviour
{
    //send email by opening a email software before that
    public void SendEmail()
    {
        string email = "shachar.oz@gmail.com";
        string subject = MyEscapeURL("New Order: warehouse "+System.DateTime.Now.Date);
        string body = MyEscapeURL("My Body\r\nFull of non-escaped chars");

        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    string MyEscapeURL(string URL)
    {
        return WWW.EscapeURL(URL).Replace("+", "%20");
    }




    /**
     * doesnt work. requires a specific email that is unsecured
     */
    //send immediately from code without nothing
    public void SendEmailImmediately() {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("shachar.oz@gmail.com");
        mail.To.Add("we@flux-experiences.com");
        mail.Subject = "SMTP New Order: warehouse " + System.DateTime.Now.Date;
        mail.Body = "SMTP My Body\r\nFull of non-escaped chars";
        // you can use others too.
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("shachar.oz@gmail.com", "yourpass") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };

        smtpServer.Send(mail);
    }
}
