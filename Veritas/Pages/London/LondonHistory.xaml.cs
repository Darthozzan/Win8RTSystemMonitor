﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Veritas.Classes;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Veritas.Pages.London
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LondonHistory : Page
    {
        const string XML = "http://k11.dt.hv.se/~SGDAS034/generatexml.php";
        
        XmlDocument xmlDocument;
        DateTime previousDateTime;

        long previousRxBytes;
        long previousTxBytes;

        bool loadTimer;

        DateTime from;
        DateTime to;

        public LondonHistory()
        {
            this.loadTimer = true;
            from = DateTime.Now.AddHours(-3);
            to = DateTime.Now;
            this.loadXML(XML);
            this.InitializeComponent();

            this.updatesText.Text = "latest updates";
            this.selectedDate.Text = "";

            DispatcherTimer xmlTimer = new DispatcherTimer();
            xmlTimer.Interval = TimeSpan.FromSeconds(70);
            xmlTimer.Tick += xmlTimer_Tick;
            xmlTimer.Start();

            this.headerControl.OnBackClick += headerControl_OnBackClick;
            this.headerControl.historyBtn.Visibility = Visibility.Collapsed;
            this.headerControl.Foreground = Colors.Crimson;
            this.headerControl.ServerName = "England Server";

            this.cpuChart.SetTitle("CPU Usage");
            this.memoryChart.SetTitle("Memory Usage");
            this.diskChart.SetTitle("HDD Usage");
            this.swapChart.SetTitle("Swap Memory Free");
            this.rxDeltaChart.SetTitle("RX Bytes Increase");
            this.txDeltaChart.SetTitle("TX Bytes Increase");

            this.calenderControl.OnSelectedDateTime += calenderControl_OnSelectedDateTime;
        }

        void calenderControl_OnSelectedDateTime(DateTime dateTime)
        {
            this.calenderControl.Visibility = Visibility.Collapsed;
            this.from = dateTime;
            this.to = dateTime.AddHours(3);
            this.loadTimer = false;
            this.loadXML(XML);
            this.updatesText.Text = "updates from";
            this.selectedDate.Text = dateTime.ToString("yyyy-MM-dd HH:mm");
        }

        private void xmlTimer_Tick(object sender, object e)
        {
            if (loadTimer)
                this.loadXML(XML);
        }

        public async void loadXML(string URL)
        {
            string xmlFile = XML + "?machine=1&from=" + from.ToString("yyyyMMddHH:mm") + "&to=" + to.ToString("yyyyMMddHH:mm");

            XmlLoadSettings loadSettings = new XmlLoadSettings();
            loadSettings.ProhibitDtd = false;
            loadSettings.ResolveExternals = true;

            xmlDocument = await XmlDocument.LoadFromUriAsync(new Uri(xmlFile), loadSettings);

            XmlNodeList machineNodes = xmlDocument.GetElementsByTagName("Machine");

            this.cpuChart.Clear();
            this.memoryChart.Clear();
            this.diskChart.Clear();
            this.swapChart.Clear();
            this.rxDeltaChart.Clear();
            this.txDeltaChart.Clear();

            this.previousRxBytes = 0;
            this.previousTxBytes = 0;

            int i = -1;
            for (i = 0; i < machineNodes.Length; i++)
            {
                DateTime dateTime = Convert.ToDateTime(
                    ((XmlElement)machineNodes[i]).GetElementsByTagName("Date_").Item(0).InnerText + " " +
                    ((XmlElement)machineNodes[i]).GetElementsByTagName("time").Item(0).InnerText);

                if (i == 0)
                {
                    this.cpuChart.SetLeftLabel(dateTime.ToString("HH:mm"));
                    this.memoryChart.SetLeftLabel(dateTime.ToString("HH:mm"));
                    this.diskChart.SetLeftLabel(dateTime.ToString("HH:mm"));
                    this.swapChart.SetLeftLabel(dateTime.ToString("HH:mm"));
                    this.rxDeltaChart.SetLeftLabel(dateTime.ToString("HH:mm"));
                    this.txDeltaChart.SetLeftLabel(dateTime.ToString("HH:mm"));
                }

                if (previousDateTime == dateTime)
                    continue;

                previousDateTime = dateTime;

                // CPU
                this.cpuChart.AddDataPoints(new NameValueItem(dateTime, (int)(double.Parse(((XmlElement)machineNodes[i]).GetElementsByTagName("cpuLoad").Item(0).InnerText) * 100)));

                // Memory
                this.memoryChart.AddDataPoints(new NameValueItem(dateTime, int.Parse(((XmlElement)machineNodes[i]).GetElementsByTagName("memoryUse").Item(0).InnerText)));

                // Disc
                this.diskChart.AddDataPoints(new NameValueItem(dateTime, int.Parse(((XmlElement)machineNodes[i]).GetElementsByTagName("diskUse").Item(0).InnerText)));

                // Swap
                this.swapChart.AddDataPoints(new NameValueItem(dateTime, int.Parse(((XmlElement)machineNodes[i]).GetElementsByTagName("swapFree").Item(0).InnerText)));

                // RX bytes
                long rxValue = RXDelta(long.Parse(((XmlElement)machineNodes[i]).GetElementsByTagName("rxBytes").Item(0).InnerText));
                
                if (rxValue > 0)
                    this.rxDeltaChart.AddDataPoints(new NameValueItem(dateTime, rxValue));

                // TX bytes
                long txValue = TXDelta(long.Parse(((XmlElement)machineNodes[i]).GetElementsByTagName("txBytes").Item(0).InnerText));

                if (txValue > 0)
                    this.txDeltaChart.AddDataPoints(new NameValueItem(dateTime, txValue));

                if (!loadTimer)
                    if (this.cpuChart.Count() == 30 || this.memoryChart.Count() == 30 ||
                        this.diskChart.Count() == 30 || this.swapChart.Count() == 30 ||
                        this.rxDeltaChart.Count() == 30 || this.txDeltaChart.Count() == 30)
                        break;
            }

            if (i > 0)
            {
                // Sätt lineChart labels
                this.cpuChart.SetRightLabel(this.cpuChart.GetLastItem().DateTime.ToString("HH:mm"));
                this.memoryChart.SetRightLabel(this.memoryChart.GetLastItem().DateTime.ToString("HH:mm"));
                this.diskChart.SetRightLabel(this.diskChart.GetLastItem().DateTime.ToString("HH:mm"));
                this.swapChart.SetRightLabel(this.swapChart.GetLastItem().DateTime.ToString("HH:mm"));
                this.rxDeltaChart.SetRightLabel(this.rxDeltaChart.GetLastItem().DateTime.ToString("HH:mm"));
                this.txDeltaChart.SetRightLabel(this.txDeltaChart.GetLastItem().DateTime.ToString("HH:mm"));
            }              
        }

        public long RXDelta(long rxBytes)
        {
            if (previousRxBytes > 0)
            {
                long r = rxBytes - previousRxBytes;

                previousRxBytes = rxBytes;

                return r;
            }
            else
            {
                previousRxBytes = rxBytes;
                return 0;
            }
        }

        public long TXDelta(long txBytes)
        {
            if (previousTxBytes > 0)
            {
                long r = txBytes - previousTxBytes;

                previousTxBytes = txBytes;

                return r;
            }
            else
            {
                previousTxBytes = txBytes;
                return 0;
            }
        }

        void headerControl_OnBackClick(object sender, EventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void calender_Click(object sender, RoutedEventArgs e)
        {
            if (this.calenderControl.Visibility == Visibility.Collapsed)
                this.calenderControl.Visibility = Visibility.Visible;
            else
                this.calenderControl.Visibility = Visibility.Collapsed;
        }
    }
}