using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DSAssignment
{
    public partial class Form1 : Form
    {
        string currentFocus = null;
        List<Button> processList = new List<Button>();
        List<Button> processListAdd = new List<Button>();
        Dictionary<string, int> eventCountPerProcess = new Dictionary<string, int>();
        Dictionary<string, Button> processWithBtnObject = new Dictionary<string, Button>();
        Dictionary<string, string> eventRecord = new Dictionary<string, string>();
        Dictionary<string, string> eventCordinates = new Dictionary<string, string>();
        List<string> connectionDetails = new List<string>();
        Dictionary<string, string> printCordinates = new Dictionary<string, string>();

        ContextMenu rightClick;
        MenuItem addEvent;
        char eventNames = Convert.ToChar(65);
        public Form1()
        {
            InitializeComponent();
            this.VScroll = true;
            addEvent = new MenuItem("Outgoing");
            addEvent.Click += Mouse_Click;
            rightClick = new ContextMenu();
            rightClick.MenuItems.Add(addEvent);
        }

        private void createProcess_click(object sender, EventArgs e)
        {
            int process = Convert.ToInt32(noOfProcesses.Text.Trim());
            int locationX = 300;
            int locationY = 100;

            for (int loop = 1; loop <= process; loop++)
            {
                Button processP1 = new Button();
                processP1.Name = "Process_" + Convert.ToString(loop);
                processP1.Location = new Point(locationX, locationY);
                processP1.Size = new Size(500, 20);
                processP1.BackColor = Color.Transparent;
                //processP1.
                this.Controls.Add(processP1);
                locationY = locationY + 100;
                //processP1.Click += new EventHandler(Mouse_Click);
                //rightClick.MenuItems.Add(addEvent);
                //processP1.ContextMenu = rightClick;
                processList.Add(processP1);
                eventCountPerProcess.Add(processP1.Name, 0);
                processWithBtnObject.Add(processP1.Name, processP1);
                eventRecord.Add(processP1.Name, null);
            }
            locationX = 850;
            locationY = 100;
            foreach (Button btn in processList)
            {

                Button plusBtn = new Button();
                plusBtn.Name = btn.Name + "_plus";
                plusBtn.Text = "+";
                plusBtn.Location = new Point(locationX, locationY);
                plusBtn.Size = new Size(20, 20);
                plusBtn.Click += new EventHandler(AddEvent_Click);
                this.Controls.Add(plusBtn);
                locationY = locationY + 100;

            }

            locationX = 250;
            locationY = 100;
            int count = 1;
            foreach (Button btn in processList)
            {

                Button plusBtn = new Button();
                plusBtn.Name = btn.Name + "_plus";
                plusBtn.Text = "P"+count.ToString();
                plusBtn.Location = new Point(locationX, locationY);
                plusBtn.Size = new Size(40, 20);
                plusBtn.Click += new EventHandler(AddEvent_Click);
                this.Controls.Add(plusBtn);
                locationY = locationY + 100;
                count++;

            }          
        }

        private void Mouse_Click(Object s, EventArgs e)
        {
            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            string destinationEvent = (s as MenuItem).Text;

            string[] startCordinates = eventCordinates[currentFocus].Split('_');
            string[] endCordinates = eventCordinates[destinationEvent].Split('_');
            startX = Convert.ToInt32(startCordinates[0]);
            startY = Convert.ToInt32(startCordinates[1]);
            endX = Convert.ToInt32(endCordinates[0]);
            endY = Convert.ToInt32(endCordinates[1]);

            connectionDetails.Add(currentFocus + "_" + destinationEvent);
            Graphics g = this.CreateGraphics();
            Point myStartPoint = new Point(startX, startY);
            Point myEndPoint = new Point(endX, endY - 2);
            Pen skyBluePen = new Pen(Brushes.Black);
            skyBluePen.Width = 4.0F;

            // Set the LineJoin property.
            skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            skyBluePen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(skyBluePen, myStartPoint, myEndPoint);

        }
        private void Focus_Click(Object s, EventArgs e)
        {
            currentFocus = (s as Button).Text;
            //MessageBox.Show(currentFocus);
            //MenuItem itemList = (s as MenuItem).Name;



        }

        private void AddEvent_Click(Object s, EventArgs e)
        {
            int newBtnLocX = 300;
            int newBtnLocY = 100;
            int eventNums = 0;
            string eventList = null;
            string coordinateRecords = null;


            string btnName = (s as Button).Name;
            Point location = (s as Button).Location;
            string[] splitName = btnName.Split('_');
            string btnKey = "Process_" + splitName[1];
            eventNums = eventCountPerProcess[btnKey];
            newBtnLocX = 300 + eventNums * 100;
            newBtnLocY = location.Y;
            eventCountPerProcess[btnKey] = eventNums + 1;
            eventList = eventRecord[btnKey];
            //MessageBox.Show(splitName[1]);
            Button declareEvent = new Button();
            declareEvent.Name = "Process_" + splitName[1] + "_Event_" + eventNames;
            declareEvent.Text = eventNames.ToString();
            declareEvent.Size = new Size(20, 20);
            declareEvent.Location = new Point(newBtnLocX, newBtnLocY - 20);
            declareEvent.BringToFront();
            declareEvent.MouseDown += Focus_Click;
            declareEvent.ContextMenu = rightClick;
            declareEvent.ForeColor = Color.DarkBlue;
            declareEvent.Visible = true;
            eventList = eventList + "_" + eventNames;
            eventRecord[btnKey] = eventList;
            coordinateRecords = newBtnLocX.ToString() + "_" + (newBtnLocY - 20).ToString();
            eventCordinates.Add(eventNames.ToString(), coordinateRecords);
            eventNames++;
            Button btn = processWithBtnObject[btnKey];
            this.Controls.Add(declareEvent);

            //MessageBox.Show(eventCountPerProcess[btnKey].ToString());
            addEvent.MenuItems.Clear();
            foreach (string evn in eventRecord.Keys)
            {

                if (eventRecord[evn] != null)
                {
                    string[] getEvent = eventRecord[evn].Split('_');
                    for (int innerLoop = 1; innerLoop < getEvent.Length; innerLoop++)
                    {
                        MenuItem newItem = new MenuItem(getEvent[innerLoop]);
                        newItem.Click += Mouse_Click;
                        addEvent.MenuItems.Add(newItem);
                    }
                }
            }
        }



        private void calculateCoordinates_Click(object sender, EventArgs e)
        {

            CalculateCordinates();
            PrintFinalCoordinates();
        }

        private void CalculateCordinates()
        {


            int[] getCordinates = new int[eventRecord.Count];
            EmptyArray(ref getCordinates);
            printCordinates.Clear();
            foreach (string record in eventRecord.Keys)
            {
                string[] processName = record.Split('_');
                int processNum = Convert.ToInt32(processName[1]);
                string[] eventName = eventRecord[record].Split('_');
                for (int loop = 0; loop < eventName.Length - 1; loop++)
                {

                    getCordinates[processNum - 1] = loop + 1;
                    printCordinates.Add(eventName[loop + 1], string.Join(",", getCordinates));
                    EmptyArray(ref getCordinates);


                }

            }
            foreach (string record in eventRecord.Keys)
            {
                foreach (string conn in connectionDetails)
                {
                    string[] connDet = conn.Split('_');
                    int[] cod1 = Array.ConvertAll(printCordinates[connDet[0]].Split(','), int.Parse);
                    int[] cod2 = Array.ConvertAll(printCordinates[connDet[1]].Split(','), int.Parse);

                    for (int loop = 0; loop < cod2.Length; loop++)
                    {
                        cod2[loop] = Math.Max(cod1[loop], cod2[loop]);


                    }
                    printCordinates[connDet[1]] = string.Join(",", cod2);

                    foreach (string record1 in eventRecord.Keys)
                    {
                        if (eventRecord[record1].IndexOf(connDet[1], StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            string[] listEvent1 = eventRecord[record1].Split('_');
                            int index = Array.IndexOf(listEvent1, connDet[1]);

                            for (int inner = index + 1; inner < listEvent1.Length; inner++)
                            {
                                int[] cod3 = Array.ConvertAll(printCordinates[listEvent1[inner]].Split(','), int.Parse);
                                for (int loop = 0; loop < cod2.Length; loop++)
                                {
                                    cod3[loop] = Math.Max(cod2[loop], cod3[loop]);
                                    printCordinates[listEvent1[inner]] = string.Join(",", cod3);
                                }
                            }
                        }
                    }



                }
            }


        }

        private void PrintFinalCoordinates()
        {
            foreach (string record in eventRecord.Keys)
            {
                string[] eventName = eventRecord[record].Split('_');
                for (int loop = 0; loop < eventName.Length - 1; loop++)
                {

                    string[] eventCord = eventCordinates[eventName[loop + 1]].Split('_');
                    Label cord = new Label();
                    cord.Text = printCordinates[eventName[loop + 1]];
                    cord.Name = "Label" + eventName[loop + 1];
                    cord.Location = new Point(Convert.ToInt32(eventCord[0]), Convert.ToInt32(eventCord[1]) + 40);
                    this.Controls.Add(cord);


                }
            }
        }

        private void EmptyArray(ref int[] getCordinates)
        {

            for (int initlize = 0; initlize < getCordinates.Length; initlize++)
            {
                getCordinates[initlize] = 0;
            }
        }
    }
}

