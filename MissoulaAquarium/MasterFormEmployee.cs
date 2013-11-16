﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MissoulaAquarium
{
    public partial class MasterFormEmployee : Form
    {
        private string currUser = "";
        private List<Event> eventsAvail = new List<Event>();
        private List<Event> eventsSigned = new List<Event>();
        private List<Employee> employees = new List<Employee>();
         private List<Shift> employeeShift = new List<Shift>();

        public MasterFormEmployee(string currUser )
        {
            InitializeComponent();
            this.currUser = currUser;

            //populte events with hard coded values
            eventsAvail.Add(new Event("Whale Watch", "12/12/2013", "3:00 pm", "Missoula Aquarium", 1));
            eventsAvail.Add(new Event("Open Discussion", "12/15/2013", "6:00 pm", "University of Montana", 2));
            eventsAvail.Add(new Event("Seal Play-time", "12/17/2013", "1:00 pm", "Missoula Aquarium", 3));
            eventsAvail.Add(new Event("Pot Luck Dinner", "12/20/2013", "5:00 pm", "Caras Park", 4));

            addToListBoxAvailEvents();

            //populte employees with hard coded values
            int userNum = int.Parse(currUser);
            Employee current=new Employee("John Lee", userNum, "Associate");
            employees.Add(current);
            employees.Add(new Employee("Mary Jane", userNum+1, "Associate"));
            employees.Add(new Employee("Fred Savage", userNum+2, "Manager"));
            employees.Add(new Employee("Todd Regal", userNum+3, "Gift Shop Clerk"));

            foreach (Employee e in employees)
            {
                Console.WriteLine(e);
            }

             Shift currentEmpSch=new Shift(current, "Off", "9:00 am\n5:00 pm", "9:00 am\n5:00 pm", "9:00 am\n5:00 pm", "9:00 am\n5:00 pm", "9:00 am\n5:00 pm", "Off");
             employeeShift.Add(currentEmpSch);
             ListViewItem item = new ListViewItem(new[] { "" + currentEmpSch.emp.empID, currentEmpSch.emp.empName, currentEmpSch.mon, currentEmpSch.tue, currentEmpSch.wed, currentEmpSch.thu, currentEmpSch.fri, currentEmpSch.sat, currentEmpSch.sun });
          //  ListViewItem item = new ListViewItem(currentEmpSch);
              scheduleListBox.Items.Add(item);
            //    scheduleListBox.DataSource=employeeShift;
            
        }

        private void addToListBoxAvailEvents()
        {

            eventsAvailListBox.DataSource = eventsAvail;
            eventsAvailListBox.SelectedIndex = 0;
        }

        private void passwordTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void eventsAvailListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            //add selected item to signed up box
            int index = eventsAvailListBox.SelectedIndex;
            Event temp = eventsAvail.ElementAt(index);
            eventsSigned.Add(temp);
            addToListBoxSignedEvents();
        }

        private void addToListBoxSignedEvents()
        {
            //add event to signed up listbox
            List<Event> temp = new List<Event>();
            //must use new array for some reason or it will not work
            foreach (Event e in eventsSigned)
            {
                temp.Add(e);
            }
            eventsSignedListBox.DataSource = temp;

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //cancel selected item in signed up box
            if ((eventsSigned.Count) != 0)
            {
                int index = eventsSignedListBox.SelectedIndex;
                eventsSigned.RemoveAt(index);
                addToListBoxSignedEvents();
            }
            else
            {
                //if there is no event to cancel
                MessageBox.Show("There are no events to cancel!");
            }
        }
    }
}
