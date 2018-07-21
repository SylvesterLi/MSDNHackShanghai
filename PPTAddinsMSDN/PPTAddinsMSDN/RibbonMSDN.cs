using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Office.Tools.Ribbon;

namespace PPTAddinsMSDN
{
    public partial class RibbonMSDN
    {
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

        }

        private void upLoadimg_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void btnChecker_Click(object sender, RibbonControlEventArgs e)
        {
            //ThisAddIn.myCustomTaskPane.Visible = !ThisAddIn.myCustomTaskPane.Visible;
            


        }
    }
}
