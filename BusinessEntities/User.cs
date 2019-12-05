using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class User : BusinessEntities.IUser
    {
        #region Instance Properties
        private int userID;
        private string username;
        private string password;
        private string userType;
        private bool online;

        #endregion

        #region Instance Properties
        public int UserID
        {
            get
            {
                return userID; ;
            }
            set
            {
                userID = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public bool Online
        {
            get
            {
                return online;
            }
            set
            {
                online = value;
            }
        }

        #endregion
        #region Constructors
        public User()
        {
            throw new System.NotImplementedException();
        }

        public User(int userID, string username, string password, string userType, bool online)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.userType = userType;
            this.online = online;
        }

        #endregion


    }
}
