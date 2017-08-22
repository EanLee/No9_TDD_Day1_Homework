using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStatistic
{
    public class OrderStatistic<T>
    {
        private List<T> _datas = new List<T>();
        public OrderStatistic()
        {

        }
        public OrderStatistic(List<T> source)
        {
            _datas.AddRange(source);
        }

        public string StatisticCategory { get; set; }

        public List<int> GetStatistic(int i)
        {
            throw new NotImplementedException();
        }
    }
}
