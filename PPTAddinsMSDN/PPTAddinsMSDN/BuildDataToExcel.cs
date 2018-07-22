using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTAddinsMSDN
{
    public static class BuildDataToExcel
    {

        public static void AddToExcel(string t, string h)
        {
            try
            {
                double a = Convert.ToDouble(t.Trim());
                double b = Convert.ToDouble(h.Trim());
                RibbonMSDN ribbonMSDN = Globals.Ribbons.RibbonMSDN;
                ribbonMSDN.AddData(a, b);
            }
            //进行转换
            catch
            {

            }
            
        }
    }
}
