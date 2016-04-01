using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    public class FertilizerNeed
    {
        ReadTXTFile mapOfAgriculturalComplex = new ReadTXTFile();
        OverlappingPlots overLapFinder = new OverlappingPlots();
        List<GardenPlot> plotList = new List<GardenPlot>();
        List<GardenPlot> overLappedReturn1 = new List<GardenPlot>();
        List<GardenPlot> overLappedReturn2 = new List<GardenPlot>();
        public decimal FindTotalFertilizer(string fileName)
        {
            decimal MainArea = 0m;
            decimal OverLapArea = 0m;
            decimal TotalFertilizerNeed = 0m;
            plotList = mapOfAgriculturalComplex.ReadTxtCreatePlotList(fileName);
            overLappedReturn1 = overLapFinder.GetOverLappingPlots(plotList);
            overLappedReturn2 = overLapFinder.GetOverLappingPlots(overLappedReturn1);
            OverLapArea = GetAreaOfPlots(overLappedReturn1) - GetAreaOfPlots(overLappedReturn2);
            MainArea = GetAreaOfPlots(plotList) - OverLapArea;
            TotalFertilizerNeed = MainArea / 2;
            return TotalFertilizerNeed;
        }
        public int GetAreaOfPlots(List<GardenPlot> listOfPlots)
        {
            int AreaTotal = 0;
            foreach(GardenPlot plot in listOfPlots)
            {
                AreaTotal += plot.WidthOfPlot * plot.HeightOfPlot;
            }
            return AreaTotal;
        }
        public void WriteToTXT(string fileName, string filename2)
        {
            StringBuilder txtPlotRow = new StringBuilder();
            decimal WriteList = FindTotalFertilizer(filename2);
            txtPlotRow.AppendLine(WriteList + " Gallons of Fertilizer Needed To Fertilize All The Plots Currently In Use At The Garden Community.");
            File.WriteAllText(fileName, txtPlotRow.ToString());
        }
    }
}
