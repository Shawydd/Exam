using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DAL
{
    internal interface IDAL<T>
    {
        public void FindAll();
        public void FindById(string id);
        public bool Insert();
        public void Update(string id);
        public bool DeleteById(string id);
    }
}
