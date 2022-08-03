using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Filter Commands
        List<T> GetAll();
        List<T> GetActive();
        List<T> GetModified();
        List<T> GetDeleted();

        //Modify Commands

        void Add(T item);
        void AddRange(List<T> list);
        void Update(T item);
        void UpdateRance(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);
        void SetActive(T item);
        void SetActiveRange(List<T> list);

        //Linq Commands

        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);


        T Find(int id);


        List<T> GetFirstData(int number);
        List<T> GetLastData(int number);
        List<T> GetData(int number);

    }
}
