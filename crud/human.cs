using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    public class human
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }

        public string job { get; set; }

        public db db1 = new db();
        public bool register(human human)
        {
            if (!exsit(human))
            {
                db1.human.Add(human);
                db1.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool exsit(human human)
        {
            var a = db1.human.Where(i => i.name == human.name).ToList();
            if (a.Count() == 0)
            {
                return false;
            }
            else { return true; }
        }

        public human readbyid(int id)
        {
            db1.human.Where(i=>i.id == id).FirstOrDefault();
            return db1.human.FirstOrDefault();
        }
        public List <human> readbyname(string s)
        {
           return db1.human.Where(i => i.name.Contains(s)).ToList();
        }
        public List<human> readbyall()
        {
            return db1.human.ToList();
        }
        public void delete(int id)
        {

             human human = readbyid(id);
            db1.human.Remove(human);
            db1.SaveChanges();

        }
        public void update(int id, human human)
        {
          var human1 = db1.human.Where(i => i.id == id).FirstOrDefault();
            human1.name = human.name;
            human1.family = human.family;
            human1.job = human.job;
        }
    }
}
