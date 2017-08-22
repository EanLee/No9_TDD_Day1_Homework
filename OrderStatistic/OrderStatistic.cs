using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderStatistic
{
    public class OrderStatistic<T> where T : class, new()
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

        public List<int> GetSumByGroupCount(int count)
        {
            if (count == 0)
                return new List<int>() { 0 };

            if (count < 0)
                throw new ArgumentException();

            var member = typeof(T).GetMember(StatisticCategory);

            //int idx = 0;
            int sum = 0;
            List<int> result = new List<int>();

            var lst = _datas.Select(x => (int)typeof(T).GetProperty(StatisticCategory).GetValue(x)).ToList();

            for (int idx = 0; idx < lst.Count(); idx++)
            {
                sum += lst[idx];

                if (((idx + 1) % count == 0) || ((idx + 1) == lst.Count))
                {
                    result.Add(sum);
                    sum = 0;
                }
            }
            
            return result;
        }
    }
}
