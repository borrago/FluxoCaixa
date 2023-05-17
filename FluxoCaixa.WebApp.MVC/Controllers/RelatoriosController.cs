using FluxoCaixa.Lancamentos.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace FluxoCaixa.WebApp.MVC.Controllers
{
    [Authorize]
    public class RelatoriosController : Controller
    {
        private readonly ILancamentoAppService _lancamentoAppService;

        public RelatoriosController(ILancamentoAppService lancamentoAppService)
        {
            _lancamentoAppService = lancamentoAppService;
        }

        // GET: Relatorio
        public IActionResult Index()
            => View();

        // GET: Relatorio/2023-17-05
        public async Task<IActionResult> Gerar(DateTime dataRecebimento, CancellationToken cancellationToken)
        {
            var lancamentos = await _lancamentoAppService.ObterTodosAsNoTrackingAsync(cancellationToken);
            var lancamentosFiltered = lancamentos.Where(w => w.DataRecebimento.Date == dataRecebimento.Date).ToList();

            return File(GerarRelatorioArquivoBytes(lancamentosFiltered.ToArray()), "application/vnd.ms-excel", $"consolidado-{dataRecebimento.Date}.csv");
        }

        private static byte[] GerarRelatorioArquivoBytes(object[] relatorio, bool hasHeader = true, bool isUtf8 = false, bool withEndSemiColonRow = true)
        {
            if (relatorio == null)
                return null;

            var json = JsonConvert.SerializeObject(relatorio, new Newtonsoft.Json.Converters.StringEnumConverter());
            var values = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            var h = values.FirstOrDefault().Keys.Where(w => !w.ToUpper().Equals("ID"));
            var header = "";
            foreach (var item in h)
                header = header + item + ";";

            var contents = values.Select(s =>
            {
                var c = "";
                var pos = 0;
                foreach (var item in s)
                {
                    pos++;
                    if (pos == 1)
                        continue;

                    c = c + item.Value + ";";
                }

                return c;
            });

            var listCsv = new List<string>();

            if (hasHeader)
                listCsv.Add(header);

            foreach (var item in contents)
                listCsv.Add(item);

            var sb = new StringBuilder();
            foreach (var item in listCsv)
            {
                if (withEndSemiColonRow)
                    sb = sb.Append(item.Replace("\n", ""));
                else
                    sb = sb.Append(item.Remove(item.Length - 1).Replace("\n", ""));

                sb.Append("\r\n");
            }

            if (isUtf8)
                return Encoding.UTF8.GetBytes(sb.ToString());

            return Encoding.GetEncoding(1252).GetBytes(sb.ToString());
        }
    }
}
