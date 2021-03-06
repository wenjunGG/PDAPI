﻿using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pd.Api.Helper
{
    public class UserInfo : IUserInfo
    {
        public Guid UserId
        {
            get { return GetUserId(); }
        }

        public Guid EnterpriseId
        {
            get { return GetEnterpriseId(); }
        }

        private string[] GetUser()
        {
            return HttpContext.Current.User.Identity.Name.Split(',');
        }

        private Guid GetUserId()
        {
            var userId = new Guid();
            if (GetUser().Count() == 2)
            {
                Guid.TryParse(GetUser()[1], out userId);
            }
            return userId;
        }

        private Guid GetEnterpriseId()
        {
            var enterpriseId = new Guid();
            if (GetUser().Count() == 2)
            {
                Guid.TryParse(GetUser()[0], out enterpriseId);
            }
            return enterpriseId;
        }
    }
}