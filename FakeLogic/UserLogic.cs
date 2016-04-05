using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace FakeLogic
{
    public class UserLogic : IUserLogic
    {
        /// <summary>
        /// База данных
        /// </summary>
        public ProjectDBDataContext Db { get; set; }

        /// <summary>
        /// Все созданные посты
        /// </summary>
        public IQueryable<NewsFeedContent> NewsFeedContents
        {
            get
            {
                return Db.NewsFeedContent;
            }
        }

        /// <summary>
        /// Новостная лента по пользователю
        /// </summary>
        public IQueryable<NewsFeed> NewsFeeds
        {
            get
            {
                return Db.NewsFeed;
            }
        }
        
        /// <summary>
        /// Подписки
        /// </summary>
        public IQueryable<Subscription> Subscriptions
        {
            get
            {
                return Db.Subscription;
            }
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public IQueryable<User> Users
        {
            get
            {
                return Db.User;
            }
        }

        List<User> users = new List<User>();
        List<NewsFeed> posts = new List<NewsFeed>();
        List<NewsFeedContent> contents = new List<NewsFeedContent>();

        /// <summary>
        /// Добавить нового пользователя/ Зарегистрироваться
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            if (user.Id == 0)
            {
                Db.User.InsertOnSubmit(user);
                Db.User.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить/Изменить аватар пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool AddAvatar(int id, string path)
        {
            User user1 = Db.User.FirstOrDefault(p => p.Id == id);
            if (user1 == null)
            {
                return false;
            }
            user1.AvatarPath = path;
            Db.User.Context.SubmitChanges();
            return true;
        }

        /// <summary>
        /// Создать новый пост
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool AddPost(int id, NewsFeedContent content)
        {
            if (Db.NewsFeedContent.FirstOrDefault(p => p.Content == content.Content) == null)
            {
                return false;
            }
            Db.NewsFeedContent.InsertOnSubmit(content);
            Db.NewsFeedContent.Context.SubmitChanges();
            Db.NewsFeed.InsertOnSubmit(new NewsFeed() { UserId = id, NewsFeedId = contents.Last().Id });
            Db.NewsFeed.Context.SubmitChanges();
            return true;
        }

        /// <summary>
        /// Получить данные поста по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsFeedContent GetPostContent(int id)
        {
            return NewsFeedContents.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Получить данные пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return Users.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Получить данные о подписке по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Subscription GetSubscription(int id)
        {
            return Subscriptions.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Удалить данного пользователя по Id (Для администраторов)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveUser(int id)
        {
            var user = GetUser(id);
            if (user == null)
            {
                return false;
            }
            Db.User.DeleteOnSubmit(user);
            Db.User.Context.SubmitChanges();
            return true;
        }
        
        /// <summary>
        /// Удалить данный пост по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemovePost(int id)
        {
            var post = GetPostContent(id);
            if (post == null)
            {
                return false;
            }
            Db.NewsFeedContent.DeleteOnSubmit(post);
            Db.NewsFeedContent.Context.SubmitChanges();
            Db.NewsFeed.DeleteOnSubmit(Db.NewsFeed.FirstOrDefault(p => p.NewsFeedId == id));
            Db.NewsFeed.Context.SubmitChanges();
            return true;
        }
        
        /// <summary>
        /// Изменить содержимое поста
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contentpost"></param>
        /// <returns></returns>
        public bool UpdatePost(int id, string contentpost)
        {
            var post = Db.NewsFeedContent.Where(p => p.Id == id).FirstOrDefault();
            if (post != null)
            {
                post.Content = contentpost;
                Db.NewsFeedContent.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Подписаться
        /// </summary>
        /// <param name="idSubscriber"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool Subscribe(int idSubscriber, int idUser)
        {
            Subscription sub = Db.Subscription.Where(p => p.IdSubscriber == idSubscriber && p.IdSubscriber == idSubscriber).FirstOrDefault();
            if (sub == null)
            {
                sub.IdSubscriber = idSubscriber;
                sub.IdUser = idUser;
                Db.Subscription.InsertOnSubmit(sub);
                Db.Subscription.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Отписаться
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Unsubscribe(int id)
        {
            var sub = GetSubscription(id);
            if (sub == null)
            {
                return false;
            }
            Db.Subscription.DeleteOnSubmit(sub);
            Db.Subscription.Context.SubmitChanges();
            return true;
        }



        #region not use
        //List<User> users = new List<User>();
        //List<NewsFeed> posts = new List<NewsFeed>();
        //List<NewsFeedContent> contents = new List<NewsFeedContent>();
        //public void Add(User user)
        //{
        //    users.Add(user);
        //}

        //public bool AddAvatar(User user, string path)
        //{
        //    var user1 = GetUser(user.Id);
        //    if (user == null)
        //    {
        //        return true;
        //    }
        //    user1.AvatarPath = path;
        //    return true;
        //}

        //public void AddPost(int id, NewsFeed post, NewsFeedContent content)
        //{
        //    contents.Add(content);
        //    posts.Add(new NewsFeed() { UserId = id, NewsFeedId = contents.Last().Id });
        //}

        //public User GetUser(int id)
        //{
        //    return users.Where(x => x.Id == id).FirstOrDefault();
        //}


        //public NewsFeedContent GetPostContent(int id)
        //{
        //    return contents.Where(x => x.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    return users.ToList();
        //}

        //public bool Remove(int id)
        //{
        //    var user = GetUser(id);
        //    if (user == null)
        //    {
        //        return true;
        //    }
        //    users.Remove(user);
        //    return true;
        //}

        //public bool Update(User user)
        //{
        //    var user1 = GetUser(user.Id);
        //    if (user == null)
        //    {
        //        return true;
        //    }
        //    user1.Login = user.Login;
        //    user1.Password = user.Password;
        //    return true;
        //}
        #endregion

    }
}
