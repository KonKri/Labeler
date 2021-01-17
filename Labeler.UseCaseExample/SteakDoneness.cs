using Labeler.Core.Attributes;

namespace Labeler.UseCaseExample
{
    /// <summary>
    /// This an example of a steak doneness levels.
    /// Notice we are using the label attribute wherever it's nessesary.
    /// </summary>
    enum SteakDoneness
    {
        Rare,
        
        [Label("Medium Rare")]
        MediumRare,
        
        Medium,
        
        [Label("Medium Rare")]
        MediumWell,

        [Label("Well Done")]
        [Label("Well")] // "well done" level can be found just as "well" as well...
        WellDone,
    }
}
