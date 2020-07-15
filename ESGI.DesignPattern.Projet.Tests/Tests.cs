using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void Get_trips_from_user()
        {
            User user = new User();
            Session.GetInstance().Connect(user);
            Assert.NotNull(Service.GetTripsByUser(user));
            Session.GetInstance().Disconnect(user);
        }

        [Fact]
        public void Get_trips_from_user_with_1_friend()
        {
            User user = new User();
            Session.GetInstance().Connect(user);
            User friend = new User();
            user.AddFriend(friend);
            Assert.NotNull(Service.GetTripsByUser(user));
            foreach (Trip trip in friend.trips) Assert.Contains(trip, Service.GetTripsByUser(user));
            Session.GetInstance().Disconnect(user);
        }

        [Fact]
        public void Not_Logged_in()
        {
            User user = new User();
            Assert.Throws<UserNotLoggedInException>(() => Service.GetTripsByUser(user));
        }
        [Fact]
        public void Logged_out()
        {
            User user = new User();
            Session.GetInstance().Connect(user);
            Session.GetInstance().Disconnect(user);
            Assert.Throws<UserNotLoggedInException>(() => Service.GetTripsByUser(user));
        }

        [Fact]
        public void Cant_log_in_if_already_logged_in()
        {
            User user = new User();
            Session.GetInstance().Connect(user);
            Assert.Throws<DependendClassCallDuringUnitTestException>(() => Session.GetInstance().Connect(user));
            Session.GetInstance().Disconnect(user);
        }

        [Fact]
        public void Cant_log_off_if_already_loged_off()
        {
            User user = new User();
            Session.GetInstance().Connect(user);
            Session.GetInstance().Disconnect(user);
            Assert.Throws<DependendClassCallDuringUnitTestException>(() => Session.GetInstance().Disconnect(user));
        }

    }
}

