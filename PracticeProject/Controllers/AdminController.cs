using Microsoft.AspNetCore.Mvc;
using PracticeProject.Persistence;
using System.Net.Mail;
using System.Net;
using PracticeProject.Models;
using Microsoft.AspNetCore.Http;

namespace PracticeProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPaymentService _paymentService;
        private readonly IAuth _auth;
        public string accesstoken;
        private ISession AdminLoginSession { get; set; }
        public AdminController(AppDbContext context,IPaymentService paymentService,IAuth auth, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context; 
            _paymentService = paymentService;
            _auth = auth;
            AdminLoginSession = httpContextAccessor.HttpContext.Session;
            accesstoken = string.IsNullOrEmpty(AdminLoginSession.GetString("token")) ? "" : AdminLoginSession.GetString("token");
        }
        [HttpGet] public IActionResult Login()
        { 
            return View(new LoginViewModel()); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            ValidateUser();
            if (!ModelState.IsValid) 
             return View(model); 
           // return RedirectToAction("Index", "Home"); 
             else
            ModelState.AddModelError("", "Invalid login attempt."); 
            return View(model); 
        }

        public IActionResult SendMails()
        { 
            var users = _context.GetUsersFromSP(); 
            foreach (var user in users)
            { 
                SendEmail(user.Email, "Welcome!", $"Hello {user.Name}, this is a test mail."); 
            } 
            return Ok("Emails sent successfully!"); 
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // STARTTLS
                Credentials = new NetworkCredential("amarnath.k@smartsoft.in", "baxk gkju byfw ejei".Replace(" ","")),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            { 
                From = new MailAddress("amarnath.k@smartsoft.in"), 
                Subject = subject,
                Body = body, 
                IsBodyHtml = true, 
            }; 
            mailMessage.To.Add(toEmail); 
            smtpClient.Send(mailMessage);
        }
        //DI
        public async Task<IActionResult> Pay(decimal amount)
        {
            bool result = await _paymentService.ProcessPayment(amount);
            return result ? Ok("Payment successful") : BadRequest("Payment failed");
        }
        //jwt
        public string ValidateUser()
        {
            string token = _auth.GenerateToken("user","pwd");
            HttpContext.Session.SetString("token", token);
            return token;
        }
    }
}
