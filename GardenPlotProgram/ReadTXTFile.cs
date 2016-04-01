using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    public class ReadTXTFile
    {
        public List<GardenPlot> ReadTxtCreatePlotList(string fileName)
        {
            List<GardenPlot> plotMap = new List<GardenPlot>();
            GardenPlot newPlot = new GardenPlot();
            StreamReader reader = new StreamReader(File.OpenRead(fileName));
            while (!reader.EndOfStream)
            {
            string line = reader.ReadLine();
            newPlot = ConvertTxtToPlot(line);
                plotMap.Add(newPlot);
            }
            return plotMap;
        } 
        public GardenPlot ConvertTxtToPlot (string rowOfData)
        {
            GardenPlot plotToReturn = new GardenPlot();
            string[] plotPointData = rowOfData.Split(',');
            plotToReturn.OwnerName = plotPointData[0];
            plotToReturn.XAxisPoint = Convert.ToInt32(plotPointData[1]);
            plotToReturn.YAxisPoint = Convert.ToInt32(plotPointData[2]);
            plotToReturn.WidthOfPlot = Convert.ToInt32(plotPointData[3]);
            plotToReturn.HeightOfPlot = Convert.ToInt32(plotPointData[4]);
            return plotToReturn;
        }
    }
}
