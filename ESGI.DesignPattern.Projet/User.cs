using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class UserSession
    {
        private static readonly UserSession userSession = new UserSession();
        public User User { get; set; }


        private UserSession()
        {
        }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        //public bool IsUserLoggedIn(User user)
        //{
        //    throw new DependendClassCallDuringUnitTestException(
        //     "UserSession.IsUserLoggedIn() should not be called in an unit test");
        //}

        public bool IsUserLoggedIn(User user)
        {
            return User == user;
        }

        //public User GetLoggedUser()
        //{
        //    throw new DependendClassCallDuringUnitTestException(
        //        "UserSession.GetLoggedUser() should not be called in an unit test");
        //}
    }

    public class User
    {
        //private List<Trip> trips = new List<Trip>();
        //private List<User> friends = new List<User>();
        public List<Trip> trips { get; private set; }
        public List<User> friends { get; private set; }

        public User() 
        {
            this.trips = new List<Trip>();
            this.friends = new List<User>();
        }

        //public List<User> GetFriends()
        //{
        //    return friends;
        //}

        //public List<Trip> Trips()
        //{
        //    return trips;
        //}

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Trip trip)
        {
            trips.Add(trip);
        }
    }
}
