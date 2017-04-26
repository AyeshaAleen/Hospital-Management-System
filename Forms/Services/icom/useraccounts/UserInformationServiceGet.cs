using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using DAO.itinsync.icom.userregion;
using DAO.itinsync.icom.userrole;
using DAO.itinsync.icom.views;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.session.user;
using Domains.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using Services.itinsync.icom.useraccounts.DTO;
using System.Collections.Generic;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.audit;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.SecurityManager;

namespace Services.user
{
    public class UserInformationServiceGet : FrameAS
    {
        UserInformation userInfo = null;
        protected override IResponseHandler executeBody(object o)
        {

             userInfo = new UserInformation();
            UserInformationInDTO indto = (UserInformationInDTO)o;
            UserAccounts user = UserAccountsDAO.getInstance(dbContext).readByUserName(indto.userName);
            if (user != null)
            {
                

                if ( SecurityManager.DecodeString(user.password).Trim() == indto.password.Trim())
                {
                    if (user.isLock != ApplicationCodes.TRUE_INDICATOR.ToString())
                    {
                        user.password = "**********";
                        userInfo.userAccount = user;
                        List<UserPermission> userPermission = UserPermissionDAO.getInstance(dbContext).readByUserID(user.userID);
                        userInfo.userPermissions = userPermission;
                        List<UserRole> userRole = UserRoleDAO.getInstance(dbContext).readByUserID(user.userID);
                        userInfo.userRoles = userRole;
                        userInfo.userTeams = UserTeamViewDAO.getInstance(dbContext).readByUserID(user.userID);
                        userInfo.userRegion = UserRegionDAO.getInstance(dbContext).readByUserID(user.userID);
                        userInfo.authorise = true;
                        getHeader().userID = user.userID;
                        getHeader().userinformation = userInfo;


                    }
                    else
                    {
                        userInfo.errorBlock.ErrorCode = ApplicationCodes.ERROR_INVALID_INACTIVE;
                        userInfo.errorBlock.ErrorText = LookupTransConstant.LOGIN_USER_INACTIVE_MESSAGE;
                    }
                }
                else
                {
                    userInfo.errorBlock.ErrorCode = ApplicationCodes.ERROR_INVALID_PASSWORD;
                    userInfo.errorBlock.ErrorText = LookupTransConstant.LOGIN_PASSWORD_INVALID_MESSAGE;
                }
            }
            else
            {
                userInfo.errorBlock.ErrorCode = ApplicationCodes.ERROR_INVALID_USERNAME;
                userInfo.errorBlock.ErrorText = LookupTransConstant.LOGIN_USER_INVALID_MESSAGE;
            }
            return userInfo;
        }

        protected override void perCommit()
        {

            if (userInfo.authorise)
                audit(AuditEventCodes.LOGIN_USER_SUCCESSFULLY, LookupTransConstant.LOGIN_USER_SUCCESSFULLY);
            else
                audit(AuditEventCodes.LOGIN_USER_FAILED, LookupTransConstant.LOGIN_USER_FAILED);


        }
    }
}