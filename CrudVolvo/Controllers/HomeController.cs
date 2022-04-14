using CrudVolvo.Models;
using CrudVolvo.Services;
using CrudVolvo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Volvo.Data;

namespace CrudVolvo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CaminhaoService caminhaoServico;
        public HomeController(VolvoDBContext context)
        {
            this.caminhaoServico = new CaminhaoService(context);
        }

        public IActionResult Index()
        {
            var caminhoes = caminhaoServico.GetAll().Select(c => new CaminhaoViewModel
            {
                Id = c.Id,
                Placa = c.Placa,
                Modelo = c.Modelo,
                AnoModelo = c.AnoModelo,
                AnoFabricacao = c.AnoFabricacao
            });

            return View(caminhoes);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CadastroCaminhao(Caminhao caminhao)
        {
            return View(caminhao);
        }

        public IActionResult EditarCaminhao(int idCaminhao)
        {
            Caminhao caminhao = caminhaoServico.FindById(idCaminhao);

            return RedirectToAction("CadastroCaminhao", caminhao);
        }

        public IActionResult SalvarCaminhao(Caminhao caminhao)
        {
            List<String> ModeloValidoLista = new List<string> { "FH", "FM" };
            if (!ModeloValidoLista.Contains(caminhao.Modelo))
            {
                caminhao.Modelo = null;
                return RedirectToAction("CadastroCaminhao", caminhao);
            }

            if (caminhao.Id <= 0)
            {
                caminhaoServico.Adicionar(caminhao);
            }
            else
            {
                caminhaoServico.Editar(caminhao);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverCaminhao(int idCaminhao)
        {
            caminhaoServico.Remover(idCaminhao);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}