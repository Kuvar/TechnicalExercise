using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalExercise.Models;

namespace TechnicalExercise.Services.Interfaces
{
    public interface IDataStore
    {
        Task<bool> AddAsync(UserModel item);
        Task<bool> UpdateAsync(UserModel item);
        Task<bool> DeleteAsync(string id);
        Task<UserModel> GetAsync(string id);
        Task<IEnumerable<UserModel>> GetAsync(bool forceRefresh = false);
        Task<IEnumerable<UserModel>> FilterAsync(string txt);
    }
}
