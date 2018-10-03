using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace Project_File
{
    public partial class Fun : Form
    {
        public Fun()
        {
            InitializeComponent();
            Res.Visible = false;
            tab.SelectedIndex = 0;
        }


        private void Sum_Click(object sender, EventArgs e)
        {
            string table = tab.Text + ".xml";
            string col_name = comboBox2.Text;
            string function = "function.xml";
            if (File.Exists(table) && File.Exists(function))
            {

                XmlDocument fun = new XmlDocument();
                XmlDocument doc = new XmlDocument();
                doc.Load(table);
                fun.Load(function);
                XmlNodeList list = doc.GetElementsByTagName(col_name);
                XmlNodeList list_fun = fun.GetElementsByTagName("SUM");
                if (list_fun[0].Attributes["datatype"].Value == list[0].Attributes["datatype"].Value)
                {

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        float sum = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            float z = int.Parse(list[i].ChildNodes[0].InnerText);
                            sum += z;
                        }

                        Res.Text = "The Sum Of " + comboBox2.Text + " : " + sum.ToString();
                        Res.Visible = true;
                    }
                }
                else
                {
                    Res.Text = "Datatype Doesn Not Match";
                    Res.Visible = true;
                }
            }
        }

        private void Average_Click(object sender, EventArgs e)
        {
            string table = tab.Text + ".xml";
            string col_name = comboBox2.Text;
            string function = "function.xml";
            if (File.Exists(table) && File.Exists(function))
            {

                XmlDocument fun = new XmlDocument();
                XmlDocument doc = new XmlDocument();
                doc.Load(table);
                fun.Load(function);
                XmlNodeList list = doc.GetElementsByTagName(col_name);
                XmlNodeList list_fun = fun.GetElementsByTagName("Avreage");
                if (list_fun[0].Attributes["datatype"].Value == list[0].Attributes["datatype"].Value)
                {

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        double average = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            int s = int.Parse(list[i].ChildNodes[0].InnerText);
                            average += s;
                        }

                        double ave = (average / (list.Count));

                        Res.Text = "The Average Of " + comboBox2.Text + " : " + ave.ToString();
                        Res.Visible = true;
                    }
                }
                else
                {
                    Res.Text = "Datatype Doesn Not Match";
                    Res.Visible = true;
                }
            }
        }

        private void Min_Click(object sender, EventArgs e)
        {
            string table = tab.Text + ".xml";
            string col_name = comboBox2.Text;
            string function = "function.xml";
            if (File.Exists(table) && File.Exists(function))
            {

                XmlDocument fun = new XmlDocument();
                XmlDocument doc = new XmlDocument();
                doc.Load(table);
                fun.Load(function);
                XmlNodeList list = doc.GetElementsByTagName(col_name);
                XmlNodeList list_fun = fun.GetElementsByTagName("Min");
                if (list_fun[0].Attributes["datatype"].Value == list[0].Attributes["datatype"].Value)
                {

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        double min = 100000000;
                        for (int i = 0; i < list.Count; i++)
                        {
                            int s = int.Parse(list[i].ChildNodes[0].InnerText);
                            if (s < min) min = s;
                        };
                        Res.Text = "The Min Of " + comboBox2.Text + " : " + min.ToString();
                        Res.Visible = true;
                    }
                }
                else
                {
                    Res.Text = "Datatype Doesn Not Match";
                    Res.Visible = true;
                }
            }
        }

        private void Max_Click(object sender, EventArgs e)
        {
            string table = tab.Text + ".xml";
            string col_name = comboBox2.Text;
            string function = "function.xml";
            if (File.Exists(table) && File.Exists(function))
            {

                XmlDocument fun = new XmlDocument();
                XmlDocument doc = new XmlDocument();
                doc.Load(table);
                fun.Load(function);
                XmlNodeList list = doc.GetElementsByTagName(col_name);
                XmlNodeList list_fun = fun.GetElementsByTagName("Max");
                if (list_fun[0].Attributes["datatype"].Value == list[0].Attributes["datatype"].Value)
                {

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        float max = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            int s = int.Parse(list[i].ChildNodes[0].InnerText);
                            if (s > max) max = s;
                        }

                        Res.Text = "The Max Of " + comboBox2.Text + " : " + max.ToString();
                        Res.Visible = true;
                    }
                }
                else
                {
                    Res.Text = "Datatype Doesn Not Match";
                    Res.Visible = true;
                }
            }
        }
        private void Count_Click(object sender, EventArgs e)
        {
            string table = tab.Text + ".xml";
            string col_name = comboBox2.Text;
            string function = "function.xml";
            if (File.Exists(table) && File.Exists(function))
            {

                XmlDocument fun = new XmlDocument();
                XmlDocument doc = new XmlDocument();
                doc.Load(table);
                fun.Load(function);
                XmlNodeList list = doc.GetElementsByTagName(col_name);
                XmlNodeList list_fun = fun.GetElementsByTagName("Count");
                if (list_fun[0].Attributes["datatype"].Value == list[0].Attributes["datatype"].Value|| list_fun[1].Attributes["datatype"].Value == list[0].Attributes["datatype"].Value)
                {

                    if (list.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        float count = list.Count;

                        Res.Text = "The Count Of " + comboBox2.Text + " : " + count.ToString();
                        Res.Visible = true;
                    }
                }
                else
                {
                    Res.Text = "Datatype Doesn Not Match";
                    Res.Visible = true;
                }
            }
        }

        private void Fun_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            XmlDocument x = new XmlDocument();
            x.Load(tab.SelectedItem.ToString() + ".xml");
            int a = x.DocumentElement.FirstChild.ChildNodes.Count;
            List<string> l = new List<string>();
            /*foreach (var tagItem in x.DocumentElement.FirstChild.C)
             {
                 l.Add(tagItem.ToString());
             }*/
            for (int i = 1; i < a; i++)
            {
                l.Add(x.DocumentElement.FirstChild.ChildNodes[i].Name.ToString());
            }
            comboBox2.DataSource = l;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Res_Click(object sender, EventArgs e)
        {

        }
    }
}
