using ApiNetCoreMonoLegal.Models;
using ApiNetCoreMonoLegal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreMonoLegal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly BillsService _billService;
        private readonly EmailService _emailService;

        public BillsController(BillsService billService, EmailService emailService)
        {
            _billService = billService;
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult<getResponse> Get()
        {
            var bills = _billService.Get();
            var result = new { ok = true, bills };
            return CreatedAtRoute("", result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ChangeStatus value)
        {
            var _id = value._id;
            var bill = _billService.Get(_id);
            var status = bill.Estado;
            var to = bill.email;
            var response = bill;

            switch(status)
            {
                case "primerrecordatorio":

                    bill.Estado = "segundorecordatorio";
                    _billService.Update(_id, bill);

                    var TotalFactura = bill.TotalFactura;
                    var text = "Se le informa que su deuda pasará" +
                        " a estado de mora si no cancela su respectivo valor de $"
                        + TotalFactura;
                    _emailService.SendEmail(text, to);

                    response = bill;

                    break;
                case "segundorecordatorio":

                    bill.Estado = "desactivado";
                    _billService.Update(_id, bill);

                    var TotalFactura2 = bill.TotalFactura;
                    var text2 = "Se le informa que su deuda pasará" +
                        " a estado de mora si no cancela su respectivo valor de $"
                        + TotalFactura2;
                    _emailService.SendEmail(text2, to);

                    response = bill;
                    break;
                default:
                    response = null;
                    break;
            }
            var result = new { ok = true, response };
            return CreatedAtRoute("", result);
        }
    }
}
