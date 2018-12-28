using Projeto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class TesteController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaId = 1,
                Nome = "Teste"
            },
            new Categoria()
            {
                CategoriaId = 2,
                Nome = "jajaja"
            },
            new Categoria()
            {
                CategoriaId = 3,
                Nome = "jajjajs"
            },
            new Categoria()
            {
                CategoriaId = 4,
                Nome = "lololo"
            },
            new Categoria()
            {
                CategoriaId = 5,
                Nome = "lokjdd"
            }
        };

        // GET: Teste
        public ActionResult Index()
        {
            return View(categorias);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = 
                categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }
        
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }


    }
}