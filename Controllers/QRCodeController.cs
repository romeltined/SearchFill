using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using SearchFill.Data;
using SearchFill.Hubs;
using SearchFill.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchFill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        private readonly SearchFillContext _context;
        private readonly IHubContext<LoginXHub> _loginxContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public QRCodeController(SearchFillContext context,
                                UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager,
                                IHubContext<LoginXHub> loginxContext)
        {
            _loginxContext = loginxContext;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
 

        [HttpGet]
        public async Task<string> Get()
        {
            var query = Request.Query;
            var email = query["email"].ToString();
            var connectionId = query["connectionId"].ToString();

            try
            {
                {
                    await _loginxContext.Clients.Client(connectionId).SendAsync("ReceiveCredential", email);
                }
                return "value";
            }
            catch
            {
                return "value";
            }

            
        }

        // POST api/<QRCodeController>
        [HttpPost]
        public async Task<IActionResult> Post([Bind("email,connectionId")] QRCodeDTO qRCodeDTO)
        {
            string domainName = "192.168.10.145:8181";  
            string qrText = @"http://" + domainName + "/api/Qrcode/?email="+ qRCodeDTO.Email + "&connectionId=" + qRCodeDTO.ConnectionId;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            string imageBase64Data = Convert.ToBase64String(BitmapToBytes(qrCodeImage));
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);

            return Ok(imageDataURL);
        }

        [HttpPost]
        [Route("[action]")]
        //api/qrcode/post
        public async Task<IActionResult> Post([FromBody] string input)
        {
            return Ok(input);
        }

        // PUT api/<QRCodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QRCodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
