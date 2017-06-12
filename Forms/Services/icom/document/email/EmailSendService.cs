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
using DAO.itinsync.icom.idocument.route;
using Domains.itinsync.icom.idocument.route;
using DAO.itinsync.icom.userrole;

using Domains.itinsync.icom.views.user;
using Domains.itinsync.icom.idocument.routeusers;
using DAO.itinsync.icom.idocument.routeusers;
using DAO.itinsync.icom.views.user;

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
            List<XDocumentRoute> routes = XDocumentRouteDAO.getInstance(dbContext).findbyDefinitionID(document.documentDefinitionID);
            foreach (XDocumentRoute route in routes)
            {
                if (route.role == ApplicationCodes.ROUTE_SEND_STORE_ALL_MANAGER)
                {
                    List<UserStoreView> userStores = UserStoreViewDAO.getInstance(dbContext).readRole(ApplicationCodes.ROLES_MANAGER);
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


            List<XDocumentRouteUsers> users = XDocumentRouteUsersDAO.getInstance(dbContext).findbyDefinitionID(document.documentDefinitionID);
            foreach (XDocumentRouteUsers user in users)
              userID.Add(user.userid);
            

        }



    }
}
