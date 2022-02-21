using ConsoleApp2;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Carpenter_Item
    {
        private int type;
        private string name;
        private string barcode;
        public void setType(int t)
        {
            if (t >= 1 && t <= 100)
                this.type = t;
            else
                Console.WriteLine("Type is invalid");
        }
        public void setname(String d)
        {
            this.name = d;
        }
        public void setBarCode(String b)
        {
            this.barcode = b;
        }
        public int getType()
        {
            return this.type;
        }
        public String getname()
        {
            return this.name;
        }
        public String getBarCode()
        {
            return this.barcode;
        }
        //Creating the parametrized constructor.
        public Carpenter_Item(int a, String b, String c)
        {
            this.type = a;
            this.name = b;
            this.barcode = c;
        }
    }


}
class Program
    {
    public static object Prallel { get; private set; }

    static void Main(string[] args)
        {
        // First of All We are creating Different items 
        Carpenter_Item one = new Carpenter_Item(1, "Hamer", "12345679");
        Carpenter_Item two = new Carpenter_Item(1, "Nails", "2323234");
        Carpenter_Item six = new Carpenter_Item(7, "Wood_Sheets", "32323");
        Carpenter_Item seven = new Carpenter_Item(7, "Saw", "232323");
        Carpenter_Item eight = new Carpenter_Item(7, "Wood_Poolish", "23232");
        Carpenter_Item nine = new Carpenter_Item(10, "SandPaper", "2323");
        Carpenter_Item ten = new Carpenter_Item(10, "Chizzel", "12123");
        Carpenter_Item eleven = new Carpenter_Item(10, "Screw_driver", "23242524");
        Carpenter_Item twelve = new Carpenter_Item(10, "Pillar", "23234");
        Carpenter_Item thirteen = new Carpenter_Item(10, "Wrench", "2325423");
        Carpenter_Item fourteen = new Carpenter_Item(10, "Doors", "45342");
        Carpenter_Item fifteen = new Carpenter_Item(10, "Table", "455223");
        Carpenter_Item sixteen = new Carpenter_Item(10, "Drill_Machine", "232424");
        Carpenter_Item three = new Carpenter_Item(10, "Cutting_Machine", "232424");
        Carpenter_Item four = new Carpenter_Item(10, "Lathe_Machine", "232424");
        Carpenter_Item five = new Carpenter_Item(10, "Milling_Machine", "232424");
        // Adding Items into the list
        List<Carpenter_Item> Carpenter_ItemList = new List<Carpenter_Item>();
        Carpenter_ItemList.Add(one);
        Carpenter_ItemList.Add(two);
        Carpenter_ItemList.Add(three);
        Carpenter_ItemList.Add(four);
        Carpenter_ItemList.Add(five);
        Carpenter_ItemList.Add(five);
        Carpenter_ItemList.Add(six);
        Carpenter_ItemList.Add(seven);
        Carpenter_ItemList.Add(eight);
        Carpenter_ItemList.Add(nine);
        Carpenter_ItemList.Add(ten);
        Carpenter_ItemList.Add(eleven);
        Carpenter_ItemList.Add(twelve);
        Carpenter_ItemList.Add(thirteen);
        Carpenter_ItemList.Add(fourteen);
        Carpenter_ItemList.Add(fifteen);
        Carpenter_ItemList.Add(sixteen);
        int Typeone = 30;
        int TypeSeven = 15;
        int TypeTen = 8;
        Parallel.ForEach(Carpenter_ItemList, e =>
        {
            if (e.getType() == 1 && Typeone > 0)
            {
                Console.WriteLine(e.getBarCode());
                Typeone--;
            }
            else if (e.getType() == 7 && TypeSeven > 0)
            {
                Console.WriteLine(e.getBarCode());
                TypeSeven--;
            }
            else if (e.getType() == 10 && TypeTen > 0)
            {
                Console.WriteLine(e.getBarCode());
                TypeTen--;
            }
        });
        Console.WriteLine("\n \n ");
        Console.WriteLine("Program Execution Ended ");
        Console.ReadLine();
    }
}
