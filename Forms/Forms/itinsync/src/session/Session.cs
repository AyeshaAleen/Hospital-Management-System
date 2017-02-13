using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Forms.itinsync.src.session
{
    public class Session
    {
        internal enum SessionKey
        {
            /// <summary>
            /// UserInformation
            /// </summary>
            USERINFORMATION,


            /// <summary>
            /// bool
            /// </summary>
            SESSIONEXIST,


            /// <summary>
            /// Int32
            /// </summary>
            CURRENTPAGE,

            /// <summary>
            /// Int32
            /// </summary>
            SUBJECTID,

            /// <summary>
            /// TDRS
            /// </summary>
            PARENTREF,


            /// <summary>
            /// Int32
            /// </summary>
            PAGEVISTSTACK,


            /// <summary>
            /// Dictionary<string, Hashtable>
            /// </summary>
            DICTONARYKEY,

            /// <summary>
            /// IResponseHandler
            /// </summary>
            DTOOBJECT,



        }

        internal class Sessions : IRequiresSessionState //:System.Web.UI.Page
        {
            public static Sessions getSession()
            {
                return new Sessions();
            }
            public string getSessionID()
            {
                return HttpContext.Current.Session.SessionID;

            }
            //************************************************************************************//        
            public void Set(SessionKey key, object value)
            {
                HttpContext.Current.Session[key.ToString()] = value;
            }
            public object Get(SessionKey key)
            {
                return (object)HttpContext.Current.Session[key.ToString()];
            }
            public void Clear(SessionKey key)
            {
                HttpContext.Current.Session[key.ToString()] = null;
            }
            public void Remove(SessionKey key)
            {
                HttpContext.Current.Session.Remove(key.ToString());
            }
            //************************************************************************************//

            internal void ClearSessionKeys()
            {
                HttpContext.Current.Session.RemoveAll();
            }
        }
    }
}