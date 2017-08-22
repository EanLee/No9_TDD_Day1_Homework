using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderStatistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;
using OrderStatistic.Model;

namespace OrderStatistic.Tests
{
    [TestClass()]
    public class OrderStatisticTests
    {
        [TestMethod]
        public void TestMethod_count_less_zero_should_ArgumentException()
        {
            OrderStatistic<Order> statistic = new OrderStatistic<Order>() { StatisticCategory = "Cost" };

            Action act = () => { statistic.GetStatistic(-1); };
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void MyTestMethod_input_count_is_0_should_0()
        {
            //  arrange
            OrderStatistic<Order> statistic = new OrderStatistic<Order> { StatisticCategory = "Cost" };

            List<int> expected = new List<int>() { 0 };

            //  act
            var actual = statistic.GetStatistic(0);


            //  assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void MyTestMethod_set_not_exist_category_should_argumentException()
        {
            //  arrange
            OrderStatistic<Order> statistic = new OrderStatistic<Order> { StatisticCategory = "Test" };

            //  act
            Action act = () => { statistic.GetStatistic(-1); };

            //  assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void MyTestMethod_count_3_and_cate_cost_should_4_element()
        {
            //  arrange
            var lst = new List<Order>
        {
            new Order() {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
            new Order() {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
            new Order() {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
            new Order() {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
            new Order() {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
            new Order() {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
            new Order() {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
            new Order() {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
            new Order() {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
            new Order() {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
            new Order() {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
        };

            var expected = new List<int>() { 6, 15, 24, 21 };

            OrderStatistic<Order> statistic = new OrderStatistic<Order>(lst) { StatisticCategory = "Cost" };

            //  act
            var actual = statistic.GetStatistic(3);

            //  assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void MyTestMethod_count_4_and_cate_Revenue_should_3_element()
        {
            //  arrange
            var lst = new List<Order>
        {
            new Order() {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
            new Order() {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
            new Order() {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
            new Order() {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
            new Order() {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
            new Order() {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
            new Order() {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
            new Order() {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
            new Order() {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
            new Order() {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
            new Order() {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
        };

            var expected = new List<int>() { 50, 66, 60 };

            OrderStatistic<Order> statistic = new OrderStatistic<Order>(lst) { StatisticCategory = "Revenue" };

            //  act
            var actual = statistic.GetStatistic(4);

            //  assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }

}