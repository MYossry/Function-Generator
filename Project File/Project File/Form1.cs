using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
namespace Project_File
{[Serializable]
    public partial class Form1 : Form
    {
        List<Empolyee> listemp = new List<Empolyee>();
        FileStream f;
        public Form1()
        {
            InitializeComponent();
            listemp.Clear();
            f= new FileStream("Empolyee.xml", FileMode.Open);
            if (f.Length > 0) { 
            XmlSerializer x = new XmlSerializer(listemp.GetType());
            listemp =(List<Empolyee>) x.Deserialize(f);
            
            }
            f.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           Empolyee emp = new Empolyee();
            emp.id = int.Parse(Id.Text);
            emp.name = NAME.Text;
            emp.position = Position.Text;
            emp.salary = int.Parse(Salary.Text);
            emp.officehour = int.Parse(Officehour.Text);
            emp.phone = Phone.Text;
            emp.department = Depart.Text;
            listemp.Add(emp);
            MessageBox.Show("aDD " + listemp.Count);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f=new FileStream("Empolyee.xml", FileMode.Truncate);
            XmlSerializer ser = new XmlSerializer(listemp.GetType());
            ser.Serialize(f, listemp);
            f.Close();
            listemp.Clear();   
            f = new FileStream("Empolyee.xml", FileMode.Open);
            if (f.Length > 0)
            {
                XmlSerializer x = new XmlSerializer(listemp.GetType());
                listemp = (List<Empolyee>)x.Deserialize(f);

            }
            f.Close();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Test d = new Test();
            d.Show();
            this.Hide();
        }
    }
}
