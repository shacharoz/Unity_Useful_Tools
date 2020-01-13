using UnityEngine;

//for email with smtp
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


//
//  last method Emailer.cs
//  http://www.mrventures.net/all-tutorials/sending-emails
using System.Collections;


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
        mail.From = new MailAddress(kSenderEmailAddress);
        mail.To.Add(kReceiverEmailAddress);
        mail.Subject = "SMTP New Order: warehouse " + System.DateTime.Now.Date;
        mail.Body = "SMTP My Body\r\nFull of non-escaped chars";
        // you can use others too.
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("shachar.oz@gmail.com", "theworldatyourfeet1") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };

        try
        {
            smtpServer.Send(mail);
        }
        catch (System.Exception e)
        {
            Debug.Log("Email error: " + e.Message);
        }
        finally
        {
            Debug.Log("Email sent!");
        }
    }







    //from new guy
    const string kSenderEmailAddress = "CoderBoy6000@gmail.com";
    const string kSenderPassword = "CoderBoy6000!!!";
    const string kReceiverEmailAddress = "we@flux-experiences.com";

    // Method 2: Server request
    const string url = "https://coderboy6000.000webhostapp.com/emailer.php";


    public UnityEngine.UI.Button btnSubmit;

    private void Start()
    {
        btnSubmit.onClick.AddListener(delegate {
             SendAnEmail("asdasdsd");
        });
    }
    // Method 1: Direct message 
    public static void SendAnEmail(string message)
    {
        // Create mail
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(kSenderEmailAddress);
        mail.To.Add(kReceiverEmailAddress);
        mail.Subject = "Email Title";
        mail.Body = message;

        // Setup server 
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential(
            kSenderEmailAddress, kSenderPassword) as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                Debug.Log("Email success!");
                return true;
            };

        // Send mail to server, print results
        try
        {
            smtpServer.Send(mail);
        }
        catch (System.Exception e)
        {
            Debug.Log("Email error: " + e.Message);
        }
        finally
        {
            Debug.Log("Email sent!");
        }
    }

    // Method 2: Server request
    public void SendServerRequestForEmail(string message)
    {
        StartCoroutine(SendMailRequestToServer(message));
    }

    // Method 2: Server request
    static IEnumerator SendMailRequestToServer(string message)
    {
        // Setup form responses
        WWWForm form = new WWWForm();
        form.AddField("name", "It's me!");
        form.AddField("fromEmail", kSenderEmailAddress);
        form.AddField("toEmail", kReceiverEmailAddress);
        form.AddField("message", message);

        // Submit form to our server, then wait
        WWW www = new WWW(url, form);
        Debug.Log("Email sent!");

        yield return www;

        // Print results
        if (www.error == null)
        {
            Debug.Log("WWW Success!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}