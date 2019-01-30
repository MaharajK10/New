using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qlik.Engine;
using Qlik.Sense;
using Qlik.Sense.Client;

namespace TestSense
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            var uri = new Uri("http://localhost:4848");
            ILocation location = Qlik.Engine.Location.FromUri(uri);
            location.AsDirectConnectionToPersonalEdition();
            using (IHub Hub = location.Hub())
            {
                label1.Text = "Product Version : " + Hub.ProductVersion();
                int i = 0;
                foreach (IAppIdentifier appIdentifier in location.GetAppIdentifiers())
                {
                    i++;
                    //textBox1.Text+=(appIdentifier.AppName+"\r\n");
                    listBox1.Items.Add(appIdentifier.AppName);
                }

                //IEnumerable<ISheet> sheets = application.GetSheets();
                //foreach (ISheet sheet1 in sheets)
                //{
                //    Console.WriteLine(sheet1.MetaAttributes.Title);
                //}
            }
        }
    }
}

