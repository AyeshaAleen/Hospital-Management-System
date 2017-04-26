using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.itinsync.icom.constant.audit
{
    public class AuditEventCodes
    {
        ///*************EVENTS******************************///
        public static readonly string AUDIT_EVENT_ORDER_INITIATE = "500";
        public static readonly string AUDIT_EVENT_ORDER_INPROGRESS = "501";
        public static readonly string AUDIT_EVENT_ORDER_COMPLETE = "502";
        public static readonly string AUDIT_EVENT_INVOICE = "503";
        public static readonly string AUDIT_EVENT_REJECT_PAYMENT = "506";
        public static readonly string AUDIT_EVENT_AUTHROIZE_PAYMENT = "509";
        public static readonly string AUDIT_EVENT_DISBURSMENT_EXCLUDE = "516";
        public static readonly string AUDIT_EVENT_COLLECTION_EXCLUDE = "515";
        public static readonly string LOGIN_USER_SUCCESSFULLY = "505";
        public static readonly string LOGIN_USER_FAILED = "506";


        public static readonly string AUDIT_EVENT_EMAIL = "517";

        public static readonly string AUDIT_EVENT_Disbursment_Send = "507";
        public static readonly string AUDIT_EVENT_COLLECTION_Send = "508";

    }
}
