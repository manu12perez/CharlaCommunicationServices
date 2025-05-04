using Azure.Communication.Sms;
using Microsoft.AspNetCore.Mvc;

namespace CharlaCommunicationServices.Controllers
{
    public class SmsController : Controller
    {
        private readonly SmsClient _smsClient;

        public SmsController(SmsClient smsClient)
        {
            _smsClient = smsClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarSms(string telefonoDestino, string mensaje)
        {
            try
            {
                var response = _smsClient.Send(
                    from: "<TU_NUMERO_DE_TELEFONO_REGISTRADO_EN_ACS>",
                    to: telefonoDestino,
                    message: mensaje
                );

                ViewBag.Resultado = $"SMS enviado correctamente. ID: {response.Value.MessageId}";
            }
            catch (Exception ex)
            {
                ViewBag.Resultado = $"Error al enviar el SMS: {ex.Message}";
            }

            return View("Index");
        }
    }
}
