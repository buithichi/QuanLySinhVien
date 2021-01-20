using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using Model.EF;

namespace Model.Dao
{
    public class UserDao
    {
        Model1 db = null;
        public UserDao()
        {
            db = new Model1();
        }
        public void Insert(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        

        public int? Login(string UserName, string PassWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if(result == null )
            {
                return 0;
            }
            else
            {
                if (result.PassWords == PassWord)
                {
                    return result.LoaiDangNhap;
                }
                else return -1;
            }
        }

        public int kiemtradangky(string username)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == username);
            if (user == null)
                return 1;
            return 0;
        }

        public int create(string UserName,string Password)
        {
                User us = new User();
                us.UserName = UserName;
                us.PassWords = Password;
                us.LoaiDangNhap = 2;
                us.xoa = 0;
                Insert(us);
                return 1;
            }
        }
    }

