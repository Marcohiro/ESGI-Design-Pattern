using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    //On transforme le UserSession en Interface utilisable par le service
    public interface IUserSession
    //public class UserSession
    {
        //private static readonly UserSession userSession = new UserSession();
        public User User { get; set; }

        //private UserSession(){}

        //public static UserSession GetInstance()
        //{
        //    return userSession;
        //}

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

    //ON réinjecte le User dans UserSession
    public class Session : IUserSession
    {
        public Session() { }
        public User User { get; set; }

        private static readonly Session session = new Session();
        public static Session GetInstance()
        {
            return session;
        }

        //STATE Design pattern

        public void Connect(User user)
        {
            if (this.User == null) this.User = user;
            else throw new UserLoggedInException();
        }

        public void Disconnect(User user)
        {
            if (this.User != null) this.User = null;
            else throw new UserNotLoggedInException();

        }
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
