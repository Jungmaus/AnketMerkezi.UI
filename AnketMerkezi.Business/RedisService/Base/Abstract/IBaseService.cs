using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnketMerkezi.Business.RedisService.Base.Abstract
{
    public interface IBaseService<T>
    {
        List<T> GetList(string key);
        T GetT(string key);
        int GetListCount(string key);
        void Delete(string key);
        void SaveList(string key, List<T> t, int minitueCount);
        void SaveT(string key, T t, int minitueCount);
        void SaveChanges();
    }
}
