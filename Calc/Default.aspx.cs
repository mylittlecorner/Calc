using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Calc
{
    public partial class _Default : Page
    {
        public List<Data> dataList;//xml data
        private WebReference.calc _webCalc;//soap service
        protected void Page_Load(object sender, EventArgs e)
        {
            this._webCalc = new WebReference.calc();
            DeserializeXmlFileToList();//loading XML file into list
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            TextBox3.Text = Convert.ToString(_webCalc.add(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text)));//soap service in action. This will throw an error if there is no internet connection.
            UpdateList("+");
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox3.Text = Convert.ToString(_webCalc.sub(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text)));
            UpdateList("-");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox3.Text = Convert.ToString(_webCalc.mul(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text)));
            UpdateList("*");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox3.Text = Convert.ToString(_webCalc.div(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text)));
            UpdateList("/");
        }

        private void UpdateList(string sign)
        {
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string result = TextBox1.Text + sign + TextBox2.Text + "=" + TextBox3.Text;
            
            dataList.Add(new Data
            {
                DateTime = datetime,
                Calc = result
            });
            SerializeListToXmlFile();
        }

        private void DeserializeXmlFileToList()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Data>));
            try
            {


                using (var reader = new StreamReader("data.xml"))
                {
                    dataList = (List<Data>)xmlSerializer.Deserialize(reader);//reading xml file if exists
                }
            }
            catch//if file is not created yet
            {
                dataList = new List<Data>();
            }

        }

        private void SerializeListToXmlFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Data>));
            using (var writer = new StreamWriter("data.xml"))
            {
                xmlSerializer.Serialize(writer, dataList);//writing to xml file
            }
        }
    }
}