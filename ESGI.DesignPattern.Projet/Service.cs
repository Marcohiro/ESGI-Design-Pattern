using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class Service
    {
        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            //User loggedUser = UserSession.GetInstance().GetLoggedUser();
            User loggedUser = UserSession.GetInstance().User;
            bool isFriend = false;
            if (loggedUser != null)
            {
                //foreach (User friend in user.GetFriends())
                foreach (User friend in user.friends)
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = DAO.FindTripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
   
}
