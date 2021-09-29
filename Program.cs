using System;
//The following gives us access to a lot of useful storage types
//For example the List 
using System.Collections.Generic;
//the following allows us to get at functions to specify things that depend on the country
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The following allows us to read and write to files
using System.IO;

namespace CurrencyAndThings
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter;
            double dMoney = 3400.26579;
            float fMoney = 3400.26579f;// explicit conversion of 3400.26 to float
            Console.WriteLine("fMoney\t\tdMoney");
            Console.WriteLine(fMoney+"\t"+dMoney);
            Console.WriteLine(fMoney.ToString("C2") + "\t" + dMoney.ToString("C2"));
            // CultureInfo.CreateSpecificCulture("da-DK") is for Denmark
            Console.WriteLine(fMoney.ToString("C2", CultureInfo.CreateSpecificCulture("da-DK")) + 
                "\t" + dMoney.ToString("C2", CultureInfo.CreateSpecificCulture("da-DK")));
            string sContinue = "yes";
            textWriter = new StreamWriter("D:CourseNotes//ConvertedData.csv");
            textWriter.WriteLine("Price in £,Price in Krona");
            List<string> los = new List<string>();
            List<float> lof = new List<float>();
            while (sContinue.Equals("yes") )//sContinue.Contains("es"))
            {
                Console.Write("What number do you want to format? ");
                string sNumber = Console.ReadLine();
                double d = Double.Parse(sNumber);
                string s = d.ToString("C2") + "\t" +
                d.ToString("C2", CultureInfo.CreateSpecificCulture("da-DK"));
                Console.WriteLine(s);
                los.Add(s);
                lof.Add((float)d);
                textWriter.WriteLine(d.ToString("C2") + "," + d.ToString("C2", CultureInfo.CreateSpecificCulture("da-DK")));
                Console.Write("More 'yes' or 'no'? ");
                //Could this cause a problem
                sContinue = Console.ReadLine().ToLower();
            }
            textWriter.Close();//always close it 
            foreach(string s in los)//foreach can only be used on things like lists
            {
                Console.WriteLine(s);
            }
            //the following
            foreach (float f in lof)
            {
                Console.WriteLine(f);
            }
            // could be done
            int c = lof.Count;
            float sum = 0;
            for(int i = 0; i < c; i++)
            {
                sum += lof[i]; //arrays begin at 0 in almost all computer programming languages
            }
            Console.WriteLine("The total value you have entered is " + sum);
            float mean = sum / c;
            Console.WriteLine("The mean is " + mean);
            lof.Sort();
            foreach(float f in lof)
            {
                Console.WriteLine(f.ToString("F2"));
            }
            
            float f1 = lof[c / 2];
            Console.WriteLine("The median is " + f1);
            Console.ReadLine();// I no longer need this line
        }
    }
}
