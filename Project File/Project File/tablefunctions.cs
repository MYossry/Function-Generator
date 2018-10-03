using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Project_File
{
    class tableFunctions
    {
        public details detailss(string departname)
        {
            List<Empolyee> le = new List<Empolyee>();
            details d = new details();
            d.NAME= departname;
            d.Salary = 0;
            d.Empolyee = 0;
            d.Hours = 0;
            FileStream f = new FileStream("Empolyee.xml", FileMode.Open);

            XmlSerializer xs = new XmlSerializer(le.GetType());
            le = (List<Empolyee>)xs.Deserialize(f);
            f.Close();
            foreach (Empolyee i in le)
            {
                if (i.department == departname)
                {
                    d.Salary += i.salary;
                    d.Hours += i.officehour;
                    d.Empolyee += 1;
                }
            }


            return d;
        }
    }
}
