using AvaliacaoD3;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoD3
{
    public interface IUser
    {


        List<User> ReadAll();

        void Create(User newUser);

        void Update(User user);

        void Delete(string idUser);
    }
}