using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Identidade.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        //Abstract vc nao trabalha com ela diretamente. Ela deve ser herdada para a outra controller usa-la
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", Errors.ToArray()},
            }));

        }


        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }



        protected bool OperacaoValida()
        {
            return !Errors.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Errors.Add(erro);
        }

        protected void LimparErrosProcessamento()
        {
            Errors.Clear();
        }
    }
}
