using AnketMerkezi.Business.RedisService.Base.Abstract;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Business.RedisService.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : AnketMerkezi.Data.ORM.Entities.BaseEntity
    {
        private IRedisClient RedisClient;

        public BaseService()
        {
            this.RedisClient = GetClient();
        }

        private IRedisClient GetClient() => new RedisManagerPool("localhost:6379").GetClient();

        public List<TEntity> GetList(string key) => JsonConvert.DeserializeObject<List<TEntity>>(RedisClient.Get<string>(key) ?? "");

        public TEntity GetT(string key) => JsonConvert.DeserializeObject<TEntity>(RedisClient.Get<string>(key) ?? "");

        public void SaveList(string key, List<TEntity> t, int minitueCount)
        {
            DateTime expiresDate = DateTime.Now.AddMinutes(minitueCount);
            string control = RedisClient.Get<string>(key);
            if (control == null)
                RedisClient.Add(key, JsonConvert.SerializeObject(t), expiresDate);
            else
                RedisClient.Replace(key, JsonConvert.SerializeObject(t), expiresDate);
        }

        public void SaveT(string key, TEntity t, int minitueCount)
        {
            DateTime expiresDate = DateTime.Now.AddMinutes(minitueCount);
            string control = RedisClient.Get<string>(key);
            if (control == null)
                RedisClient.Add(key, JsonConvert.SerializeObject(t), expiresDate);
            else
                RedisClient.Replace(key, JsonConvert.SerializeObject(t), expiresDate);
        }

        public void SaveChanges() => RedisClient.Save();

        public void Delete(string key) => RedisClient.Remove(key);

        public int GetListCount(string key) => JsonConvert.DeserializeObject<List<TEntity>>(RedisClient.Get<string>(key) ?? "") != null ? JsonConvert.DeserializeObject<List<TEntity>>(RedisClient.Get<string>(key) ?? "").Count : -1;
    }
}
