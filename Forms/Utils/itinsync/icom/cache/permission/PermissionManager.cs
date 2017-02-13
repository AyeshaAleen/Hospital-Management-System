using Domains.itinsync.icom.permission;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.cache.global;

namespace Utils.itinsync.icom.cache.permission
{
    public static class PermissionManager
    {
        public static List<Permission> readbyPageID(string pageid)
        {
           

            List<Permission> permissionList = new List<Permission>();
            foreach (DictionaryEntry entry in GlobalStaticCache.PermissionCacheMap[pageid])
            {
                Permission permission = new Permission();
                permission.Code = Convert.ToInt32(entry.Key);
                permission.text = Convert.ToString(entry.Value);
                permissionList.Add(permission);
            }
            return permissionList;
        }
        public static List<Permission> readAllPermission()
        {

            List<Permission> permissionList = new List<Permission>();

            foreach (Int32 pageid in GlobalStaticCache.PageIDCacheMap)
            {
                foreach (DictionaryEntry entry in GlobalStaticCache.PermissionCacheMap[pageid.ToString()])
                {
                    Permission permission = new Permission();
                    permission.Code = Convert.ToInt32(entry.Key);
                    permission.text = Convert.ToString(entry.Value);
                    permissionList.Add(permission);
                }
            }

            return permissionList;
        }
    }
}
