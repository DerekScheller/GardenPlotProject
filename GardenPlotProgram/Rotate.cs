using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    public class Rotate
    {
        ReadTXTFile plotMap = new ReadTXTFile();

        public List<GardenPlot> RotatePlots(string fileName)
        {
            int FlipDigitOne;
            int FlipDigitTwo;
            List<GardenPlot> plots = new List<GardenPlot>();
            plots = plotMap.ReadTxtCreatePlotList(fileName);
            foreach(GardenPlot plot in plots)
            {
                FlipDigitOne = plot.WidthOfPlot;
                FlipDigitTwo = plot.HeightOfPlot;
                plot.WidthOfPlot = FlipDigitTwo;
                plot.HeightOfPlot = FlipDigitOne;
            }
            return plots;
        }
        public void WriteToTXT(string fileName, string fileName2)
        {
            StringBuilder txtPlotRow = new StringBuilder();
            List<GardenPlot> WriteList = new List<GardenPlot>();
            WriteList = RotatePlots(fileName2);
            foreach(GardenPlot plot in WriteList)
            {
                txtPlotRow.AppendLine(plot.OwnerName + "," + plot.XAxisPoint + "," + plot.YAxisPoint + "," + plot.WidthOfPlot + "," + plot.HeightOfPlot);
            }
            File.WriteAllText(fileName, txtPlotRow.ToString());
        }
    }
}
