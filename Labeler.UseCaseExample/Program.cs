using Labeler.Core.Extentions;
using System;
using System.Linq;

namespace Labeler.UseCaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // defining our steak's levels.
            var mySteakDonenessLevel = SteakDoneness.MediumRare;
            var dimitrisSteakDonenessLevel = SteakDoneness.Medium;
            var mariaSteakDonenessLevel = SteakDoneness.WellDone;

            // displaying a story about the steaks we had.
            Console.WriteLine($"Yesterday, I ordered a {mySteakDonenessLevel.GetLabel().ToLower()} steak, " + // upon get label as string you can act on it as you wish.
                              $"while Dimitris had a {dimitrisSteakDonenessLevel.GetLabel().ToLower()} steak, " + // there is no label for Medium. Thus "Medium" will be returned.
                              $"and Maria had a {mariaSteakDonenessLevel.GetLabels().Last().ToLower()} one."); // there are multiple labels for WellDone. You can select which one you want to use.
        }
    }
}
