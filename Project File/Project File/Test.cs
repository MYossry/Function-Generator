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
using System.Xml;

using System.Xml.Serialization;

namespace Project_File
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string table = tname.Text + ".xml";
            string col_name = colname.Text;
            string function = "function.xml";
            if (File.Exists(table) && File.Exists(function))
            {

                XmlDocument fu = new XmlDocument();
                XmlDocument d = new XmlDocument();
                d.Load(table);
                fu.Load(function);
                XmlNodeList li = d.GetElementsByTagName(col_name);
                XmlNodeList list_fun = fu.GetElementsByTagName("Search");
                if (list_fun[0].Attributes["datatype"].Value == li[0].Attributes["datatype"].Value || list_fun[1].Attributes["datatype"].Value == li[0].Attributes["datatype"].Value)
                {

                    if (!File.Exists(tname.Text + ".xml")) { MessageBox.Show("Insert Table"); return; }
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();



                    string file = tname.Text;
                    string Search = textBox3.Text;
                    string col = colname.Text;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file + ".xml");
                    XmlNodeList list = doc.GetElementsByTagName(file);
                    for (int i = 0; i < list.Count; i++)
                    {
                        bool falge = true;
                        XmlNodeList child = list[i].ChildNodes;
                        string[] names = new string[child.Count];
                        string[] values = new string[child.Count];
                        for (int j = 0; j < child.Count; j++)
                        {

                            names[j] = child[j].Name.ToString();
                            values[j] = child[j].InnerText.ToString();
                            if (Search != "")
                            {
                                if (names[j] == col && values[j] != Search) falge = false;
                            }
                        }

                        if (dataGridView1.ColumnCount == 0)
                        {
                            for (int j = 0; j < child.Count; j++)
                            {
                                dataGridView1.Columns.Add(names[j], names[j]);
                            }
                        }
                        if (falge) dataGridView1.Rows.Add(values);
                    }
                }

            }
            else
            {
                MessageBox.Show("Plase Select Table Name");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tname_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument x = new XmlDocument();
            x.Load(tname.SelectedItem.ToString() + ".xml");
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
            colname.DataSource = l;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void colname_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = colname.Text;
        }
    }
}
