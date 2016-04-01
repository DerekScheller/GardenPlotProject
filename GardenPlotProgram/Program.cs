using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenPlotProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalPlotFencing TotalFence = new TotalPlotFencing();
            Rotate Rotater = new Rotate();
            OverlappingPlots OverLap = new OverlappingPlots();
            FertilizerNeed Fertilizer = new FertilizerNeed();
            IndividualPlotFencingRequirement IndividualFence = new IndividualPlotFencingRequirement();
            if (Convert.ToInt16(args.ElementAt(0)) == 1)
            {
                OverLap.WriteToTXT(args.ElementAt(2), args.ElementAt(1));
            }
            if (Convert.ToInt16(args.ElementAt(0)) == 2)
            {
            TotalFence.WriteToTXT(args.ElementAt(2), args.ElementAt(1));

            }
            if (Convert.ToInt16(args.ElementAt(0)) == 3)
            {

            IndividualFence.WriteToTXT(args.ElementAt(2), args.ElementAt(1));
            }
            if (Convert.ToInt16(args.ElementAt(0)) == 4)
            {
            Fertilizer.WriteToTXT(args.ElementAt(2), args.ElementAt(1));

            }
            if (Convert.ToInt16(args.ElementAt(0)) == 5)
            {

            Rotater.WriteToTXT(args.ElementAt(2), args.ElementAt(1));
            }

            // A friend heard you were attending devCodeCamp and asked if you would write an application 
            //to help her manage her small garden -
            //rental business.She rents out a number of random garden plots in a field, which she maintains for a fee. 
            //She has some required functionality for the application, as described below.

            // The application needs to read a user - specified plot text file that represents 
            //the rectangular garden plots' position and width/height 
            //(in feet) in the format of "x, y, w, h". For example:
            // 2, 2, 10, 20
            // 100, 10, 5, 5
            // 5, 5, 10, 10


            // The application needs to implement the following features, accessible via the command 
            //- line, and output the result to file:


            // 1.Some of the plots overlap(so customers can share portions of their gardens).
            //Write functionality to specify which plots overlap
            //(each overlapping plot should appear once and only once in the output file).
            // Command format: "PlotProgram.exe 1 <input plot file> <output plot file>"
            // Ex: "PlotProgram.exe 1 plots.txt overlapping_plots.txt"


            // 2.Find the total amount of fencing material(in feet) necessary to 
            //fence in the perimeter of each garden plot individually.
            //(Overlapping plots use the same amount of fencing material as they would if they were separate)
            //Command format: "PlotProgram.exe 2 <input plot file> <output file>"
            //Ex: "PlotProgram.exe 2 plots.txt total_fencing.txt"

            //3.Find the minimum amount of fencing material (in feet) necessary to
            //fence in all of the garden plots together in one giant rectangle.
            //Command format: "PlotProgram.exe 3 <input plot file> <output file>"
            //Ex: "PlotProgram.exe 3 plots.txt total_fencing.txt"

            //4.Find the total amount of fertilizer necessary to cover all of the garden plots, 
            //given that it takes half a bottle to fertilize a square foot of garden. 
            //(the overlapping portion of overlapping plots shouldn't be counted twice)
            //Command format: "PlotProgram.exe 4 <input plot file> <output file>"
            //Ex: "PlotProgram.exe 4 plots.txt total_fertilizer.txt"

            //5.Write functionality to rotate all of the rectangles by 90°, 180°, or 270°.
            //Command format: "PlotProgram.exe 5 <input plot file> <output plot file>"
            //Ex: "PlotProgram.exe 5 plots.txt rotated_plots.txt"

            //Beyond the above functionality, the application should not display anything 
            //to the screen or require any user interaction.


        }
    }
}
