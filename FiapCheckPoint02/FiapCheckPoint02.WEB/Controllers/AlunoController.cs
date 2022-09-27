using FiapCheckPoint02.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiapCheckPoint02.WEB.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> _lista = new List<Aluno>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _lista.RemoveAt(_lista.FindIndex(c => c.Id == id));
            TempData["msg"] = "Aluno removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {
            var index = _lista.FindIndex(c => c.Id == aluno.Id);
            _lista[index] = aluno;
            TempData["msg"] = "Aluno atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarMarcas();
            var index = _lista.FindIndex(c => c.Id == id);
            var aluno = _lista[index];
            return View(aluno);
        }
        public IActionResult Index()
        {
            return View(_lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarMarcas();
            return View();
        }

        private void CarregarMarcas()
        {
            var lista = new List<string>(new string[] {"ADS", "Engenharia",
                "Arquitetura"});
            ViewBag.curso = new SelectList(lista);
        }
        [HttpPost]
        public IActionResult Cadastrar(Aluno aluno)
        {
            aluno.Id = ++_id;
            _lista.Add(aluno);
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
