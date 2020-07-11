using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void Service_User_With_1_Friend()
        {
            User user = new User();
            User friend = new User();
            user.AddFriend(friend);
            Service service = new Service();
            foreach(Trip trip in friend.trips) Assert.Contains(trip, service.GetTripsByUser(user));
        }

    }
}

