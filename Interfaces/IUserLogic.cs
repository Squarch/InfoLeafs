using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserLogic
    {
        #region not use
        //User GetUser(int id);
        //NewsFeedContent GetPostContent(int id);
        //void Add(User user);
        //bool AddAvatar(User user, string path);
        //void AddPost(int id, NewsFeed post, NewsFeedContent content);
        //bool Remove(int id);
        //IEnumerable<User> GetAll();
        //bool Update(User user);
        #endregion
        IQueryable<User> Users { get; }
        IQueryable<NewsFeed> NewsFeeds { get; }
        IQueryable<NewsFeedContent> NewsFeedContents { get; }
        IQueryable<Subscription> Subscriptions { get; }
        User GetUser(int id);
        NewsFeedContent GetPostContent(int id);
        Subscription GetSubscription(int id);
        bool AddUser(User user);
        bool AddAvatar(int id, string path);
        bool AddPost(int id, NewsFeedContent content);
        bool RemoveUser(int id);
        bool RemovePost(int id);
        bool UpdatePost(int id, string contentpost);
        bool Subscribe(int idSubscriber, int idUser);
        bool Unsubscribe(int id);



        //bool CreateRole(Role instance);

        //bool UpdateRole(Role instance);

        //bool RemoveRole(int idRole);

    }
}
