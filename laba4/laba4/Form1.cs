using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public struct Client
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public DateTime UchetData { get; set; }
        public int PostavkaData { get; set; }
        public Client(string surname, string name, string otchestvo, DateTime uchetData)
        {
            Name = name;
            Otchestvo = otchestvo;
            Surname = surname;
            UchetData = uchetData;
            PostavkaData = 0;
        }
    }
    public partial class Form1 : Form
    {
        private List<Client> Spisok = new List<Client>();

        public static void Sravnenie(List<Client> spisok)
        {
            int j = 0, count = 0;
            int tempdata = spisok[0].UchetData.Year;
            for (int i = 0; i < spisok.Count; i++)
            {
                if(i == 0)
                {
                    Client temp1 = spisok[i];
                    temp1.PostavkaData = tempdata;
                    spisok[i] = temp1;
                    j++;
                    count++;
                }
                else
                {
                    if (spisok[i].UchetData.Year > tempdata && (count % 5) != 0)
                    {
                        j = 0;
                        tempdata = spisok[i].UchetData.Year;
                        Client temp1 = spisok[i];
                        temp1.PostavkaData = tempdata;
                        spisok[i] = temp1;
                    }
                    if (j <= 4)
                    {
                        Client temp1 = spisok[i];
                        temp1.PostavkaData = tempdata;
                        spisok[i] = temp1;
                        j++;
                        count++;
                    }            
                    else
                    {
                        j = 0;
                        tempdata++;
                        Client temp1 = spisok[i];
                        temp1.PostavkaData = tempdata;
                        spisok[i] = temp1;
                        j++;
                        count++;
                    }                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client temp = new Client(textBox4.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value);
            Spisok.Add(temp);
            Spisok = Spisok.OrderBy(itm => itm.UchetData).ToList();
            label5.Text = Spisok.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Sravnenie(Spisok);
            for (int i = 0; i < Spisok.Count; i++)
            {
                dataGridView1.Rows.Add(Spisok[i].Name, Spisok[i].Otchestvo, Spisok[i].Surname, Spisok[i].UchetData.ToShortDateString(), Spisok[i].PostavkaData);
            }     
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            dateTimePicker1.ResetText();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char с = e.KeyChar;
            if ((с < 'А' || с > 'я') && с != '\b' && с != '.')
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char с = e.KeyChar;
            if ((с < 'А' || с > 'я') && с != '\b' && с != '.')
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char с = e.KeyChar;
            if ((с < 'А' || с > 'я') && с != '\b' && с != '.')
            {
                e.Handled = true;
            }
        }
    }
}
