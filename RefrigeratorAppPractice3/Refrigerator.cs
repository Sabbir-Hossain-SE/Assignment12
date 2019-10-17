using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorAppPractice3
{

    public class Refrigerator
    {

        string dataIndex;
        private double capacity;
        private double currentUsedCapacity;
        private double remainingCapacity;
        public List<double> itemList = new List<double>();
        public List<double> weightList = new List<double>();
        public List<double>totalWeightList = new List<double>();

        public Refrigerator( double capacity)
        {
            this.capacity = capacity;
            this.remainingCapacity = capacity;
        }
        public bool store(double items, double weight)
        {

            bool flag = false;
            double totalStoringAmount = items * weight;
            if (remainingCapacity >= totalStoringAmount)
            {
                currentUsedCapacity += totalStoringAmount;
                remainingCapacity -= totalStoringAmount;

                flag = true;
               itemList.Add(items);
               weightList.Add(weight);
               totalWeightList.Add(totalStoringAmount);

            }
            return flag;
        }
        public double getCurrentUsedCapacity()
        {
            return currentUsedCapacity;
        }
        public double getRemainingCapacity()
        {
            return remainingCapacity;
        }
        public string GetData()
        {
            dataIndex = null;
            for (int i = 0; i < weightList.Count; i++) // Loop through List with for
            {
              dataIndex += Convert.ToString(itemList[i]) + "  " + Convert.ToString(weightList[i]) + "  " + Convert.ToString(totalWeightList[i])+"\n";
            }
            return dataIndex;

        }
    }
}
