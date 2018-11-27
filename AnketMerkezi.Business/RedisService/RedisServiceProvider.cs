using AnketMerkezi.Business.RedisService.EntityService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Business.RedisService
{
    public class RedisServiceProvider : IDisposable
    {
        private SupportRequestMessageService _supportRequestMessageService;
        private SupportRequestService _supportRequestService;
        private SurveyContentService _surveyContentService;
        private SurveyVisitService _surveyVisitService;
        private SurveyVisitAnswerService _surveyVisitAnswerService;
        private SurveyService _surveyService;

        public SupportRequestMessageService SupportRequestMessage { get { return _supportRequestMessageService ?? new SupportRequestMessageService(); } }
        public SupportRequestService SupportRequest { get { return _supportRequestService ?? new SupportRequestService(); } }
        public SurveyContentService SurveyContent { get { return _surveyContentService ?? new SurveyContentService(); } }
        public SurveyVisitService SurveyVisit { get { return _surveyVisitService ?? new SurveyVisitService(); } }
        public SurveyVisitAnswerService SurveyVisitAnswer { get { return _surveyVisitAnswerService ?? new SurveyVisitAnswerService(); } }
        public SurveyService Survey { get { return _surveyService ?? new SurveyService(); } }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
