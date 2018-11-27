using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnketMerkezi.Data.ORM.Entities;
using AnketMerkezi.UI.Models.Managers;
using AnketMerkezi.UI.Models.Types;
using AnketMerkezi.UI.Models.VMs.Survey;
using Microsoft.AspNetCore.Mvc;

namespace AnketMerkezi.UI.Controllers
{
    public class SurveyController : BaseController
    {
        public IActionResult Index()
        {
            int webUserID = int.Parse(GetWebUserID());
            List<SurveyIndexVM> model = new List<SurveyIndexVM>();

            List<Survey> userSurveys = RedisService.Survey.GetList(webUserID + "-Survey-Index-List");
            List<SurveyVisit> userSurveyVisits = RedisService.SurveyVisit.GetList(webUserID + "-Survey-Index-VisitList");
            if (userSurveys == null && userSurveyVisits == null)
            {
                userSurveys = Service.Survey.GetAllWithQuery(x => x.UserID == webUserID);
                userSurveyVisits = Service.SurveyVisit.GetAllWithQuery(x => userSurveys.FirstOrDefault(y => y.ID == x.SurveyID) != null).ToList();

                RedisService.Survey.SaveList(webUserID + "-Survey-Index-List", userSurveys, 30);
                RedisService.SurveyVisit.SaveList(webUserID + "-Survey-Index-VisitList", userSurveyVisits, 30);
            }

            model = userSurveys.Select(x => new SurveyIndexVM
            {
                ID = x.ID,
                AnswerCount = userSurveyVisits.Where(y => y.SurveyID == y.ID).Sum(y => y.SurveyVisitAnswers.Count),
                Name = x.Name,
                IsActive = x.IsActive,
                AddDateText = DateManager.FormatDate(x.AddDate),
                AddDate = x.AddDate,
                Link = x.LinkCode
            }).OrderByDescending(x => x.AddDate).ToList();

            return View(model);
        }

        public IActionResult Edit(string link)
        {
            int webUserID = int.Parse(GetWebUserID());
            Survey survey = Service.Survey.FirstOrDefault(x => x.LinkCode == link && x.UserID == webUserID);
            if (survey == null)
            {
                TempData["OperationStatus"] = EnumOperationStatus.Failure;
                return RedirectToAction("Index");
            }


            return View();
        }

        public IActionResult Add()
        {
            int webUserID = int.Parse(GetWebUserID());
            User user = Service.User.FirstOrDefault(x => x.ID == webUserID);
            int quota = user.AccountType == (int)EnumUserType.Normal ? 1 : user.AccountType == (int)EnumUserType.Silver ? 3 : user.AccountType == (int)EnumUserType.Gold ? 5 : 0;
            if (Service.Survey.GetAllWithQuery(x => x.UserID == webUserID && x.IsActive).Count >= quota)
            {
                TempData["OperationStatus"] = EnumOperationStatus.Failure;
                TempData["OperationStatusMessage"] = "Anket kotanız dolduğu için anket oluşturamazsınız.";
                return RedirectToAction("Index");
            }

            return View(new SurveyAdd(1));
        }

        public IActionResult Preview(string link)
        {
            int webUserID = int.Parse(GetWebUserID());
            Survey survey = Service.Survey.FirstOrDefault(x => x.LinkCode == link && x.UserID == webUserID);
            if (survey == null)
            {
                TempData["OperationStatus"] = EnumOperationStatus.Failure;
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Share()
        {
            return View();
        }

        public IActionResult ChangeStatus(int id)
        {
            int webUserID = int.Parse(GetWebUserID());
            Survey survey = Service.Survey.FirstOrDefault(x => x.ID == id);
            if (survey != null && survey.UserID == webUserID)
            {
                survey.IsActive = survey.IsActive == true ? false : true;
                Service.Survey.Update(survey);

                TempData["OperationStatus"] = EnumOperationStatus.Success;
            }
            else
                TempData["OperationStatus"] = EnumOperationStatus.Failure;

            ClearCache();
            return RedirectToAction("Index");
        }

        private void ClearCache()
        {
            string webUserID = GetWebUserID();
            RedisService.Survey.Delete(webUserID + "-Survey-Index-List");
            RedisService.Survey.Delete(webUserID + "-Survey-Index-VisitList");
        }

    }
}