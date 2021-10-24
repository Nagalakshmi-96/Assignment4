using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Values
    {
        public string Column1;
        public string Column2;
        public double Column3;
        public int Column4;
        public Values Clone()
        {
            return (Values)this.MemberwiseClone();
        }
    }
    public class Class1
    {
        static void Main()
        {
            List<Values> OrigList = new List<Values>();
            
            #region Initializing Original List
            DateTime dayStart = new DateTime(2016, 1, 1);
            double dayStartNumber = dayStart.ToOADate();

            int i;

            for ( i = 1; i <= 10; i++)
                OrigList.Add(new Values { Column1 = "B" + i, Column2 = "Item" + i, Column3 = dayStartNumber + i, Column4 = 100 + i });

            #endregion

            var CloneList = new List<Values>();

            foreach (var obj in OrigList)
                CloneList.Add((Values)obj.Clone());


            Console.WriteLine("Original List");
            foreach (var obj in OrigList)
                Console.WriteLine("{0}  {1}  {2}  {3} ", obj.Column1, obj.Column2, DateTime.FromOADate(obj.Column3).ToShortDateString(), obj.Column4);

            Console.WriteLine("------------");
            Console.WriteLine("Cloned List");
            foreach (var obj in CloneList)
                Console.WriteLine("{0}  {1}  {2}  {3} ", obj.Column1, obj.Column2, DateTime.FromOADate(obj.Column3).ToShortDateString(), obj.Column4);

            int j= 10;

            foreach (var obj in OrigList)
                obj.Column2 = "Item"+(++j);

            OrigList.RemoveAt(0);
            OrigList.RemoveAt(0);
            OrigList.Add(new Values { Column1 = "B" + i, Column2 = "Item" + (++j), Column3 = dayStartNumber + i, Column4 = 100 + i });

            Console.WriteLine("------------");
            Console.WriteLine("Altered List");
            foreach (var obj in OrigList)
                Console.WriteLine("{0}  {1}  {2}  {3} ", obj.Column1, obj.Column2, DateTime.FromOADate(obj.Column3).ToShortDateString(), obj.Column4);

            OrigList= CloneList;
            Console.WriteLine("------------");
            Console.WriteLine("After Reverting back the Changes");
            foreach (var obj in OrigList)
                Console.WriteLine("{0}  {1}  {2}  {3} ", obj.Column1, obj.Column2, DateTime.FromOADate(obj.Column3).ToShortDateString(), obj.Column4);

            Console.Read();
        }

    }
}
