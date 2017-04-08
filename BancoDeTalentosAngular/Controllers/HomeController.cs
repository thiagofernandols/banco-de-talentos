using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoDeTalentosAngular.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoDeTalentosAngular.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            using (var bd = new bd_talentosContext())
            {
                return View();
            }
        }
        public JsonResult GetTalentos()
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic talentos = bd.Talento.ToList();
                    return Json(talentos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public JsonResult GetDisponibilidade()
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic disp = bd.Disponibilidade.ToList().Distinct();
                    return Json(disp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public JsonResult GetMelhorHorario()
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic mh = bd.MelhorHorario.ToList().Distinct();
                    return Json(mh);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public JsonResult GetConhecimentoEspecifico()
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic mh = bd.ConhecimentoEspecifico.ToList();
                    return Json(mh);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost()]
        public JsonResult IncluirTalento([FromBody]Talento objeto)
        {
            try
            {
                var bd = new bd_talentosContext();
                bd.Talento.Add(objeto);
                bd.SaveChanges();
                dynamic obj = new bd_talentosContext().Talento.ToList();
                return Json(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        public JsonResult AlterarTalento([FromBody]Talento objeto)
        {
            try
            {
                var bd = new bd_talentosContext();
                bd.Talento.Update(objeto);
                bd.SaveChanges();
                dynamic obj = new bd_talentosContext().Talento.ToList();
                return Json(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        public JsonResult ExcluirTalento([FromBody]Talento objeto)
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic _item = bd.Talento.Find(objeto.IdTalento);
                    bd.Talento.Remove(_item);
                    bd.SaveChanges();
                    dynamic obj = bd.Talento.ToList();
                    return Json(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetTalento([FromBody]Talento objeto)
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic talento = bd.Talento.Find(objeto.IdTalento);                    
                    return Json(talento);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetTalentoDisponibilidade([FromBody]Talento objeto)
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic list = bd.TalentoDisponibilidade.Where(l=>l.IdTalento == objeto.IdTalento).ToList();
                    return Json(list);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetTalentoMelhorHorario([FromBody]Talento objeto)
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic list = bd.TalentoMelhorHorario.Where(l => l.IdTalento == objeto.IdTalento).ToList();
                    return Json(list);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetTalentoConhecimentos([FromBody]Talento objeto)
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic list = bd.TalentoConhecimentos.Where(l => l.IdTalento == objeto.IdTalento).ToList();
                    return Json(list);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetInfoBancaria([FromBody]Talento objeto)
        {
            using (var bd = new bd_talentosContext())
            {
                try
                {
                    dynamic list = bd.InfoBancaria.Where(l => l.IdTalento == objeto.IdTalento).ToList();
                    return Json(list);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
