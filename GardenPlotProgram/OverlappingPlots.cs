using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    public class OverlappingPlots
    {
        public List<GardenPlot> GetOverLappingPlots(List<GardenPlot> plotsToCheck)
        {
            List<GardenPlot> overLapPlot = new List<GardenPlot>();
            int upperLeftOverLapX;
            int upperLeftOverLapY;
            int lowerRightOverLapX;
            int lowerRightOverLapY;
            int cycleCount = 1;
            foreach (GardenPlot plot1 in plotsToCheck)
            {
                for (int i = cycleCount; i < plotsToCheck.Count; i++ )
                {
                    if (plot1.XAxisPoint <= (plotsToCheck.ElementAt(i).XAxisPoint + plotsToCheck.ElementAt(i).WidthOfPlot))
                        {
                            upperLeftOverLapX = plot1.XAxisPoint;
                            if (plot1.YAxisPoint <= (plotsToCheck.ElementAt(i).YAxisPoint + plotsToCheck.ElementAt(i).HeightOfPlot))
                            {
                                upperLeftOverLapY = plot1.YAxisPoint;
                            if(!((plot1.XAxisPoint + plot1.WidthOfPlot <= plotsToCheck.ElementAt(i).XAxisPoint) && (plot1.YAxisPoint + plot1.HeightOfPlot <= plotsToCheck.ElementAt(i).YAxisPoint)))
                            {

                                if (plot1.XAxisPoint <= plotsToCheck.ElementAt(i).XAxisPoint)
                                {  
                                    upperLeftOverLapX = plotsToCheck.ElementAt(i).XAxisPoint;

                                }
                                if (plot1.YAxisPoint <= plotsToCheck.ElementAt(i).YAxisPoint)
                                {
                                    upperLeftOverLapY = plotsToCheck.ElementAt(i).YAxisPoint;
                                }
                                lowerRightOverLapX = plotsToCheck.ElementAt(i).XAxisPoint + plotsToCheck.ElementAt(i).WidthOfPlot;
                                if (plot1.XAxisPoint + plot1.WidthOfPlot <= plotsToCheck.ElementAt(i).XAxisPoint + plotsToCheck.ElementAt(i).WidthOfPlot)
                                {
                                    lowerRightOverLapX = plot1.XAxisPoint + plot1.WidthOfPlot;
                                }
                                lowerRightOverLapY = plotsToCheck.ElementAt(i).YAxisPoint + plotsToCheck.ElementAt(i).HeightOfPlot;
                                if (plot1.YAxisPoint + plot1.HeightOfPlot <= plotsToCheck.ElementAt(i).YAxisPoint + plotsToCheck.ElementAt(i).HeightOfPlot)
                                {
                                    lowerRightOverLapY = plot1.YAxisPoint + plot1.HeightOfPlot;
                                }
                                GardenPlot overlapDimensions = new GardenPlot();
                                overlapDimensions.OwnerName = plot1.OwnerName + " and " + plotsToCheck.ElementAt(i).OwnerName + " share the following area in the garden.";
                                overlapDimensions.XAxisPoint = upperLeftOverLapX;
                                overlapDimensions.YAxisPoint = upperLeftOverLapY;
                                overlapDimensions.WidthOfPlot = lowerRightOverLapX - upperLeftOverLapX;
                                overlapDimensions.HeightOfPlot = lowerRightOverLapY - upperLeftOverLapY;
                                overLapPlot.Add(overlapDimensions);
                            }
                            }
                        }
                    }
                cycleCount++;
                }
            return overLapPlot;
        }
        public void WriteToTXT(string fileName, string fileName2)
        {
            StringBuilder txtPlotRow = new StringBuilder();
            List<GardenPlot> WriteList = new List<GardenPlot>();
            ReadTXTFile fieldLayout = new ReadTXTFile();
            WriteList = GetOverLappingPlots(fieldLayout.ReadTxtCreatePlotList(fileName2));
            foreach (GardenPlot overLappingPlot in WriteList)
            {
                txtPlotRow.AppendLine(overLappingPlot.OwnerName + "," + overLappingPlot.XAxisPoint + "," + overLappingPlot.YAxisPoint + "," + overLappingPlot.WidthOfPlot + "," + overLappingPlot.HeightOfPlot);
            }
            File.WriteAllText(fileName, txtPlotRow.ToString());
        }
    }
}
