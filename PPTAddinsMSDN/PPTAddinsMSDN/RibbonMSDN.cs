using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;

namespace PPTAddinsMSDN
{
    public partial class RibbonMSDN
    {
        Slide mydoc = null;
        Microsoft.Office.Interop.Excel.Worksheet dataSheet = null;

        private void RibbonMSDN_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnSocketConnect_Click(object sender, RibbonControlEventArgs e)
        {
            //开始监听端口
            //默认2018端口
            //后台开的线程自动接收
            //接收方法在SocketManagement.Receive();
            SocketManagement.SocketBind();
        }

        private void btnDisconnect_Click(object sender, RibbonControlEventArgs e)
        {
            BuildDataToExcel.AddToExcel("85","32");
        }

        private void upLoadimg_Click(object sender, RibbonControlEventArgs e)
        {
            
         
        }

        private void btnChecker_Click(object sender, RibbonControlEventArgs e)
        {
            //ThisAddIn.myCustomTaskPane.Visible = !ThisAddIn.myCustomTaskPane.Visible;
            mydoc = Globals.ThisAddIn.Application.ActivePresentation.Slides[5];
            mydoc.Export("myPathtoFile.png", "png");


        }
        public void AddData(double th,double hu)
        {
            mydoc = Globals.ThisAddIn.Application.ActivePresentation.Slides[6];


            ChartData chartData = mydoc.Shapes[2].Chart.ChartData;

            Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

            //Get the worksheet of chart
            dataSheet = dataWorkbook.Worksheets[1];


            dataSheet.Cells.Range["A2"].EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
       
            dataSheet.Cells.get_Range("A2").Value = th;
            dataSheet.Cells.get_Range("B2").Value = hu;
        }
    }
}
