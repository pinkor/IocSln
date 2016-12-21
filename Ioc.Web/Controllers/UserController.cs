using Ioc.Entities.User;
using Ioc.Service;
using Ioc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioc.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            IEnumerable<UserModel> users = userService.GetUsers().Select(u => new UserModel
            {
                FirstName = u.UserProfile.FirstName,
                LastName = u.UserProfile.LastName,
                Email = u.Email,
                Address = u.UserProfile.Address,
                ID = u.ID
            });
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateEditUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUserById(id.Value);
                model.FirstName = userEntity.UserProfile.FirstName;
                model.LastName = userEntity.UserProfile.LastName;
                model.Address = userEntity.UserProfile.Address;
                model.Email = userEntity.Email;
                model.UserName = userEntity.UserName;
                model.Password = userEntity.PassWord;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditUser(UserModel model)
        {
            if (model.ID == 0)
            {
                Ioc.Entities.User.User userEntity = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PassWord = model.Password,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IP = Request.UserHostAddress,
                    UserProfile = new UserProfile
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IP = Request.UserHostAddress
                    }
                };
                userService.InsertUser(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                Ioc.Entities.User.User userEntity = userService.GetUserById(model.ID);
                userEntity.UserName = model.UserName;
                userEntity.Email = model.Email;
                userEntity.PassWord = model.Password;
                userEntity.ModifiedDate = DateTime.Now;
                userEntity.IP = Request.UserHostAddress;
                userEntity.UserProfile.FirstName = model.FirstName;
                userEntity.UserProfile.LastName = model.LastName;
                userEntity.UserProfile.Address = model.Address;
                userEntity.UserProfile.ModifiedDate = DateTime.Now;
                userEntity.UserProfile.IP = Request.UserHostAddress;
                userService.UpdateUser(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }

            }
            return View(model);
        }

        public ActionResult DetailUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                Ioc.Entities.User.User userEntity = userService.GetUserById(id.Value);
                // model.ID = userEntity.ID;  
                model.FirstName = userEntity.UserProfile.FirstName;
                model.LastName = userEntity.UserProfile.LastName;
                model.Address = userEntity.UserProfile.Address;
                model.Email = userEntity.Email;
                model.AddedDate = userEntity.AddedDate;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            UserModel model = new UserModel();
            if (id != 0)
            {
                Ioc.Entities.User.User userEntity = userService.GetUserById(id);
                model.FirstName = userEntity.UserProfile.FirstName;
                model.LastName = userEntity.UserProfile.LastName;
                model.Address = userEntity.UserProfile.Address;
                model.Email = userEntity.Email;
                model.AddedDate = userEntity.AddedDate;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    Ioc.Entities.User.User userEntity = userService.GetUserById(id);
                    userService.DeleteUser(userEntity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}