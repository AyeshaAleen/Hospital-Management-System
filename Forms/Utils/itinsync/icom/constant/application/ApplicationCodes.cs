﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.itinsync.icom.constant.application
{
    public static class ApplicationCodes
    {
        public static readonly string DTOOBJECT = "DTOOBJECT";
        public static readonly string READONLYSTATE = "READONLYSTATE";
        public static readonly string EMAIL_CONTACT = "Emails";
        public static readonly string PHONES_CONTACT = "Phones";
        public static readonly string ADDRESS_CONTACT = "Address";


        public static readonly string TRUE_INDICATOR = "1";
        public static readonly string FALSE_INDICATOR = "0";
        public static readonly string DEFAULT_USER_LANG = "en";
        public static readonly string SOURCELOCATION = "C:/DMS/CSV";


        ///*************Roles******************************///
        public static readonly string ROLES_CUSTOMER = "3001";
        public static readonly string ROLES_SUPPLIER = "3002";
        public static readonly string ROLES_THRIRD_PARTY = "3003";


        ///**************VENDOR PAYMENT FREQUECNY*************///
        public static readonly int PAYMENT_FREQUENCY_IMMEDIATELY = 0;
        public static readonly int PAYMENT_FREQUENCY_WEEKLY = 9;
        public static readonly int PAYMENT_FREQUENCY_MONTHLY = 1;
        public static readonly int PAYMENT_FREQUENCY_2MONTHLY = 2;
        public static readonly int PAYMENT_FREQUENCY_3MONTHLY = 3;
        public static readonly int PAYMENT_FREQUENCY_4MONTHLY = 4;
        public static readonly int PAYMENT_FREQUENCY_5MONTHLY = 5;




        ///**************INVOICE STATUS CODES*************///
        public static readonly string INVOICE_STATUS_NEW = "0";
        public static readonly string INVOICE_STATUS_AUTHORISE = "1";
        public static readonly string INVOICE_STATUS_SEND = "2";
        public static readonly string INVOICE_STATUS_DEAUTHORIZE = "3";
        public static readonly string INVOICE_STATUS_REJECT = "4";
        public static readonly string INVOICE_STATUS_HOLD = "-1";

        ///**************INVOICE TYPE*************///
        
        public static readonly string INVOICE_TYPE_INVOICE_CODE = "5003";
        public static readonly string INVOICE_TYPE_COMMISSION_CODE = "5005";
        

        ///***************TRANSCATION TYPE***********///

        public static readonly string TRANTYPE_DISBURSMENT = "701";
        public static readonly string TRANTYPE_COLLECTION = "702";

        ///***************TASK STATUS***********///

        public static readonly string TASK_STATUS_NEW = "0";
        public static readonly string TASK_STATUS_COMPLETE = "1";

       

        ///***************GL STATUS***********///

        public static readonly string GL_TRANTYPE_PAYBALE = "0";
        public static readonly string GL_TRANTYPE_RECEIVEABLE = "1";
        public static readonly string GL_TRANTYPE_PAID = "2";
        public static readonly string GL_TRANTYPE_RECEIVED = "3";

        public static readonly string GL_TRANTYPE_PARTIAL_PAID = "4";
        public static readonly string GL_TRANTYPE_PARTIAL_RECEIVED = "5";



        //***********ErrorCode*********/////
        public static readonly Int32 ERROR                   = 60;
        public static readonly Int32 ERROR_INVALID_USERNAME = 60;
        public static readonly Int32 ERROR_INVALID_PASSWORD = 61;
        public static readonly Int32 ERROR_INVALID_INACTIVE = 62;
        public static readonly Int32 ERROR_USERNAME_ALREADY_EXIST = 64;
        public static readonly Int32 ERROR_TRANTYPE_MISSING = 65;
        public static readonly Int32 ERROR_PAYMENT_PROBLEM = 66;
        public static readonly Int32 ERROR_INVOICE_PROBLEM = 67;
        public static readonly Int32 ERROR_HISTORY_PROBLEM = 68;
        public static readonly Int32 ERROR_DISBURSMENT_PROBLEM = 69;
        public static readonly Int32 ERROR_COLLECTION_PROBLEM = 70;
        public static readonly Int32 ERROR_NO = 0;
        public static readonly string ERROR_TEXT = "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> ";
        public static readonly string SUCCESS_TEXT = "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a> Request completed successfully <br> ";
        public static readonly Int32 ERROR_FILEREAD_PROBLEM = 71;
    }
}
