using DAO.itinsync.icom.BaseAS.frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.response;
using Services.icom.document.email.dto;
using Domains.itinsync.icom.idocument;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Domains.itinsync.icom.idocument.definition;
using DAO.itinsync.icom.store;
using Domains.itinsync.icom.store;
using DAO.itinsync.icom.idocument.roleRoute;
using Domains.itinsync.icom.idocument.roleRoute;
using DAO.itinsync.icom.userrole;
using DAO.itinsync.icom.views.user;
using Domains.itinsync.icom.views.user;
using Domains.itinsync.icom.idocument.userRoute;
using DAO.itinsync.icom.idocument.userRoute;

namespace Services.icom.document.email
{
    
   public class EmailSendService : FrameAS
    {
        private EmailDTO dto;
        protected override IResponseHandler executeBody(object o)
        {
            dto = (EmailDTO)o;
            try
            {
                Douments document = (Douments)dto.getParentref();
                Store store = StoreDAO.getInstance(dbContext).findbyPrimaryKey(document.storeid);

                return dto;
            }
            catch (Exception ex)
            {
                dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT;
                throw new ItinsyncException(ex, dto.getErrorBlock().ErrorText, dto.getErrorBlock().ErrorCode);
            }
           

          
        }

        private void findRecipient(Douments document)
        {
            string recipient = "";
            List<Int32> userID = new List<Int32>();
            List<XDocumentRoleRoute> routes = XDocumentRoleRouteDAO.getInstance(dbContext).readbyDefinitionID(document.documentDefinitionID);
            foreach (XDocumentRoleRoute route in routes)
            {
                if (route.role == ApplicationCodes.ROUTE_SEND_STORE_ALL_MANAGER)
                {
                    List<UserStoreView> userStores =UserStoreViewDAO.getInstance(dbContext).readRole(ApplicationCodes.ROLES_MANAGER);
                    foreach (UserStoreView userStore in userStores)
                        userID.Add(userStore.userID);

                }
                else if (route.role == ApplicationCodes.ROUTE_SEND_STORE_ALL_SUPERVISOR)
                {
                    List<UserStoreView> userStores = UserStoreViewDAO.getInstance(dbContext).readRole(ApplicationCodes.ROLES_SUPERVISOR);
                    foreach (UserStoreView userStore in userStores)
                        userID.Add(userStore.userID);
                }
                else if (route.role == ApplicationCodes.ROUTE_SEND_STORE_MANAGER)
                {
                    List<UserStoreView> userStores = UserStoreViewDAO.getInstance(dbContext).readRoleAndStoreNo(ApplicationCodes.ROLES_MANAGER, document.storeid);
                    foreach (UserStoreView userStore in userStores)
                        userID.Add(userStore.userID);
                }
                else if (route.role == ApplicationCodes.ROUTE_SEND_STORE_SUPERVISOR)
                {
                    List<UserStoreView> userStores = UserStoreViewDAO.getInstance(dbContext).readRoleAndStoreNo(ApplicationCodes.ROLES_SUPERVISOR, document.storeid);
                    foreach (UserStoreView userStore in userStores)
                        userID.Add(userStore.userID);
                }
                else if (route.role == ApplicationCodes.ROUTE_SEND_STORE_GM)
                {
                    List<UserStoreView> userStores = UserStoreViewDAO.getInstance(dbContext).readRoleAndStoreNo(ApplicationCodes.ROLES_GM, document.storeid);
                    foreach (UserStoreView userStore in userStores)
                        userID.Add(userStore.userID);
                }
              
            }


            List<XDocumentUserRoute> users = XDocumentUserRouteDAO.getInstance(dbContext).findbyDocumentDefinitionID(document.documentDefinitionID);
            foreach (XDocumentUserRoute user in users)
              userID.Add(user.userid);
            

        }



    }
}
