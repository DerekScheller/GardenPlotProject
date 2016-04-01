using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    public class IndividualPlotFencingRequirement
    {
        ReadTXTFile gardenCommunityLayout = new ReadTXTFile();
        public void WriteToTXT(string fileName, string fileName2)
        {
            StringBuilder txtPlotRow = new StringBuilder();
            List<GardenPlot> WriteList = new List<GardenPlot>();
            WriteList = gardenCommunityLayout.ReadTxtCreatePlotList(fileName2);
            int fencingNeeded = 0;
            foreach (GardenPlot plot in WriteList)
            {
                fencingNeeded += (plot.HeightOfPlot * 2) + (plot.WidthOfPlot * 2);
            }
                txtPlotRow.AppendLine(fencingNeeded + " Feet Of Fence Needed To Enclose Each Plot In The Community Garden Individually.");
            File.WriteAllText(fileName, txtPlotRow.ToString());
        }
    }
}
