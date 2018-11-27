using AnketMerkezi.Business.Services.EntityService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Business.Services
{
    public class ServiceProvider : IDisposable
    {

        private SurveyContentService _surveyContentService;
        private SurveyService _surveyService;
        private SurveyVisitAnswerService _surveyVisitAnswerService;
        private SurveyVisitService _surveyVisitService;
        private UserDetailService _userDetailService;
        private UserService _userService;
        private SupportRequestService _supportRequestService;
        private SupportRequestMessageService _supportRequestMessageService;
        private SupportRequestMessageDocumentService _supportRequestMessageDocumentService;
        private UserOrderService _userOrderService;

        public SurveyContentService SurveyContent { get { return _surveyContentService ?? new SurveyContentService(); } }
        public SurveyService Survey { get { return _surveyService ?? new SurveyService(); } }
        public SurveyVisitAnswerService SurveyVisitAnswer { get { return _surveyVisitAnswerService ?? new SurveyVisitAnswerService(); } }
        public SurveyVisitService SurveyVisit { get { return _surveyVisitService ?? new SurveyVisitService(); } }
        public UserDetailService UserDetail { get { return _userDetailService ?? new UserDetailService(); } }
        public UserService User { get { return _userService ?? new UserService(); } }
        public SupportRequestService SupportRequest { get { return _supportRequestService ?? new SupportRequestService();  } }
        public SupportRequestMessageService SupportRequestMessage { get { return _supportRequestMessageService ?? new SupportRequestMessageService(); } }
        public SupportRequestMessageDocumentService SupportRequestMessageDocument { get { return _supportRequestMessageDocumentService ?? new SupportRequestMessageDocumentService(); } }
        public UserOrderService UserOrder { get { return _userOrderService ?? new UserOrderService(); } }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
