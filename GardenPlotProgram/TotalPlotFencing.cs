using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    public class TotalPlotFencing
    {
        ReadTXTFile mapOfGarden = new ReadTXTFile();
        public int GetTotalFencing(string fileName)
        {
            List<GardenPlot> plots = new List<GardenPlot>();
            plots = mapOfGarden.ReadTxtCreatePlotList(fileName);
            int upperLeftX = plots.ElementAt(0).XAxisPoint;
            int upperLeftY = plots.ElementAt(0).YAxisPoint;
            int lowerRightX = plots.ElementAt(0).XAxisPoint + plots.ElementAt(0).WidthOfPlot;
            int lowerRightY = plots.ElementAt(0).YAxisPoint + plots.ElementAt(0).HeightOfPlot;
            int totalLegnthNeeded;
            foreach (GardenPlot plot in plots)
            {
                if (plot.XAxisPoint <= upperLeftX)
                {
                    upperLeftX = plot.XAxisPoint;
                }
                if (plot.YAxisPoint <= upperLeftY)
                {
                    upperLeftY = plot.YAxisPoint;
                }
                if ((plot.WidthOfPlot + plot.XAxisPoint) >= lowerRightX)
                {
                    lowerRightX = plot.WidthOfPlot + plot.XAxisPoint;
                }
                if ((plot.HeightOfPlot + plot.YAxisPoint) >= lowerRightY)
                {
                    lowerRightY = plot.HeightOfPlot + plot.YAxisPoint;
                }
            }
            totalLegnthNeeded = ((lowerRightX - upperLeftX) * 2) + ((lowerRightY - upperLeftY) * 2);
            return totalLegnthNeeded;
        }
        public void WriteToTXT(string fileName, string fileName2)
        {
            StringBuilder txtPlotRow = new StringBuilder();
            int WriteList = GetTotalFencing(fileName2);
                txtPlotRow.AppendLine(WriteList + " Feet of Fence Needed To Enclose The Entire Garden Community.");
            File.WriteAllText(fileName, txtPlotRow.ToString());
        }
    }
}
