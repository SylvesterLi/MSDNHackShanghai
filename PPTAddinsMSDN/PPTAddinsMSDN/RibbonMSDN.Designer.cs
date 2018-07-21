namespace PPTAddinsMSDN
{
    partial class RibbonMSDN : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonMSDN()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnSocketConnect = this.Factory.CreateRibbonButton();
            this.btnDisconnect = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.comboBox1 = this.Factory.CreateRibbonComboBox();
            this.upLoadimg = this.Factory.CreateRibbonButton();
            this.btnChecker = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "MSDN New Home";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnSocketConnect);
            this.group1.Items.Add(this.btnDisconnect);
            this.group1.Items.Add(this.comboBox1);
            this.group1.Label = "Device Management";
            this.group1.Name = "group1";
            // 
            // btnSocketConnect
            // 
            this.btnSocketConnect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSocketConnect.Label = "Device Connect";
            this.btnSocketConnect.Name = "btnSocketConnect";
            this.btnSocketConnect.OfficeImageId = "ConnectorsGallery";
            this.btnSocketConnect.ShowImage = true;
            this.btnSocketConnect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSocketConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDisconnect.Label = "Disconnect All";
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.OfficeImageId = "DeleteRows";
            this.btnDisconnect.ShowImage = true;
            this.btnDisconnect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDisconnect_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.upLoadimg);
            this.group2.Items.Add(this.btnChecker);
            this.group2.Label = "MIcrosoft Service";
            this.group2.Name = "group2";
            // 
            // comboBox1
            // 
            ribbonDropDownItemImpl1.Label = "Ai-Think ESP32";
            ribbonDropDownItemImpl1.Tag = "2333";
            ribbonDropDownItemImpl2.Label = "Azure DevKit";
            ribbonDropDownItemImpl2.Tag = "2018";
            this.comboBox1.Items.Add(ribbonDropDownItemImpl1);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl2);
            this.comboBox1.Label = "Devices List";
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Text = "No devices detected";
            // 
            // upLoadimg
            // 
            this.upLoadimg.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.upLoadimg.Label = "Design Insight";
            this.upLoadimg.Name = "upLoadimg";
            this.upLoadimg.OfficeImageId = "DesignChecker";
            this.upLoadimg.ShowImage = true;
            this.upLoadimg.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.upLoadimg_Click);
            // 
            // btnChecker
            // 
            this.btnChecker.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnChecker.Label = "Count things";
            this.btnChecker.Name = "btnChecker";
            this.btnChecker.ShowImage = true;
            this.btnChecker.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnChecker_Click);
            // 
            // RibbonMSDN
            // 
            this.Name = "RibbonMSDN";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonMSDN_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSocketConnect;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDisconnect;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton upLoadimg;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnChecker;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMSDN RibbonMSDN
        {
            get { return this.GetRibbon<RibbonMSDN>(); }
        }
    }
}
