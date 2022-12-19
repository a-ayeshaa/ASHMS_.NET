using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.UserRepo
{
    internal class TokenRepo:Repo,IRepo<Token,string,Token>
    {
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string Tokenname)
        {
            var data = db.Tokens.Find(Tokenname);
            db.Tokens.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Token Get(string Tokenname)
        {
            return db.Tokens.Find(Tokenname);
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token obj)
        {
            var dbobj = db.Tokens.Find(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
