using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnketMerkezi.Data.ORM.Entities;
using AnketMerkezi.UI.Models.Types;
using AnketMerkezi.UI.Models.VMs.Panel;
using Microsoft.AspNetCore.Mvc;

namespace AnketMerkezi.UI.Controllers
{
    public class PanelController : BaseController
    {
        public IActionResult Index()
        {
            string webUserID = GetWebUserID();
            int iWebUserID = int.Parse(webUserID);

            PanelIndexVM model = new PanelIndexVM();
            model.AnsweredSupportRequestCount = RedisService.SupportRequest.GetListCount(webUserID + "-Panel-Index-SupportRequest"); 
            model.NewAnswerCount = RedisService.SurveyVisitAnswer.GetListCount(webUserID + "-Panel-Index-SurveyVisitAnswers");
            if (model.AnsweredSupportRequestCount == -1)
            {
                List<SupportRequest> supportRequests = Service.SupportRequest.GetAllWithQuery(x => x.CreaterWebUserID == iWebUserID && x.Status == (int)EnumSupportRequestType.Yanitlandi);
                RedisService.SupportRequest.SaveList(webUserID + "-Panel-Index-SupportRequest", supportRequests, 60);
                model.AnsweredSupportRequestCount = supportRequests.Count;
            }

            if(model.NewAnswerCount == -1)
            {
                List<SurveyVisitAnswer> surveyVisitAnswers = Service.SurveyVisitAnswer.GetAllWithQuery(x => x.SurveyVisit.Survey.UserID == iWebUserID && x.AddDate.Day == DateTime.Now.Day && x.AddDate.Month == DateTime.Now.Month && x.AddDate.Year == DateTime.Now.Year);
                RedisService.SurveyVisitAnswer.SaveList(webUserID + "-Panel-Index-SurveyVisitAnswers", surveyVisitAnswers, 60);
                model.NewAnswerCount = surveyVisitAnswers.Count;
            }

            return View(model);
        }
    }
}