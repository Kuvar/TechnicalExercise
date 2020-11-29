using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalExercise.Models;
using TechnicalExercise.Services.Interfaces;

namespace TechnicalExercise.Services
{
    public class DataStore : IDataStore
    {
        List<UserModel> users;

        public DataStore()
        {
            users = new List<UserModel>();

            var data = new List<UserModel>
            {
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Guy Travis", Email =  "Donec@ullamcorper.co.uk", Phone =  "6531457591", Age =  19, Postal =  "180261" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Melissa Gardner", Email =  "magna.a@lacusNullatincidunt.net", Phone =  "6558862027", Age =  45, Postal =  "560339" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Kato Lindsey", Email =  "elit@nisi.net", Phone =  "6581123840", Age =  23, Postal =  "380119" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Clinton Stein", Email =  "consequat@vitaealiquet.org", Phone =  "6592446625", Age =  59, Postal =  "460218" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Nayda Park", Email =  "magna@nonummy.edu", Phone =  "6553247533", Age =  58, Postal =  "460218" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Rhiannon Dillard", Email =  "ut@tincidunt.edu", Phone =  "6593078001", Age =  30, Postal =  "560703" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Daria Lancaster", Email =  "Integer@Nunclectuspede.org", Phone =  "6558063379", Age =  37, Postal =  "180261" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Ira Golden", Email =  "euismod.urna@pedeultrices.net", Phone =  "6569440498", Age =  39, Postal =  "460218" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Nelle Bush", Email =  "tristique.ac@malesuada.org", Phone =  "6558072875", Age =  24, Postal =  "380119" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Leah Garrison", Email =  "Integer.id@infaucibus.ca", Phone =  "6545012828", Age =  43, Postal =  "460218" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Cheyenne Parker", Email =  "euismod.in.dolor@egestaslaciniaSed.net", Phone =  "6527495515", Age =  42, Postal =  "560703" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Phelan Spears", Email =  "odio@magnaCrasconvallis.ca", Phone =  "6517431038", Age =  24, Postal =  "180261" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Tanner Duncan", Email =  "tellus@egetvolutpatornare.com", Phone =  "6534647093", Age =  27, Postal =  "460218" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Sopoline Downs", Email =  "ornare@metuseu.org", Phone =  "6572872676", Age =  36, Postal =  "560703" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Raven Brady", Email =  "arcu.Morbi@ac.com", Phone =  "6504654817", Age =  31, Postal =  "180261" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Colleen Schmidt", Email =  "montes.nascetur.ridiculus@Sed.net", Phone =  "6564603547", Age =  28, Postal =  "560703" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Alexa Sullivan", Email =  "non.enim.Mauris@diam.co.uk", Phone =  "6589825892", Age =  28, Postal =  "560703" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Henry Cannon", Email =  "semper@disparturientmontes.com", Phone =  "6505044194", Age =  36, Postal =  "460218" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Audrey Powers", Email =  "nisi.magna.sed@risus.ca", Phone =  "6554013754", Age =  37, Postal =  "380119" },
                new UserModel{ Id = Guid.NewGuid().ToString(), Name =  "Merritt Mccoy", Email =  "felis.eget.varius@iaculisaliquetdiam.org", Phone =  "6590578319", Age =  55, Postal =  "180261" }
            };

            foreach (var item in data)
            {
                users.Add(item);
            }
        }

        public async Task<IEnumerable<UserModel>> FilterAsync(string txt)
        {
            return await Task.FromResult(users.Where(s => 
                                s.Name.ToLower().Contains(txt) ||
                                s.Email.ToLower().Contains(txt) ||
                                s.Phone.Contains(txt) ||
                                s.Age.ToString().Contains(txt) ||
                                s.Postal.Contains(txt)
            ));
        }

        Task<bool> IDataStore.AddAsync(UserModel item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore.DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        async Task<UserModel> IDataStore.GetAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        async Task<IEnumerable<UserModel>> IDataStore.GetAsync(bool forceRefresh)
        {
            return await Task.FromResult(users);
        }

        Task<bool> IDataStore.UpdateAsync(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}
