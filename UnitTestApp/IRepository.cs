using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestApp.Models;

namespace UnitTestApp
{
    public interface IRepository: IDisposable
    {
        List<Computer> GetComputerList();
        Computer GetComputer(int id);
        void Create(Computer item);
        void Update(Computer item);
        void Delete(int id);
        void Save();
    }

    public class ComputerRepository : IRepository
    {
        private CompContext db;
        public ComputerRepository()
        {
            this.db = new CompContext();
        }
        public List<Computer> GetComputerList()
        {
            return db.Computers.ToList();
        }

        public void Create(Computer c)
        {
            db.Computers.Add(c);
        }

        public void Update(Computer c)
        {
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Computer c = db.Computers.Find(id);
            if(c != null)
            {
                db.Computers.Remove(c);
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Computer GetComputer(int id)
        {
            return db.Computers.Find(id);
        }
    }
}
