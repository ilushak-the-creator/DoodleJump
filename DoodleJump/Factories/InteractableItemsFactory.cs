using DoodleJump.Interfaces;
using DoodleJump.Models;

namespace DoodleJump.Factories;

public class InteractableItemsFactory
{
    private readonly MonstersFactory monstersFactory;
    private readonly BusterFactory busterFactory;
    private const int propabilityForMonstr = 5;
    private const int propabilityForBuster = 5 + propabilityForMonstr;

    public InteractableItemsFactory()
    {
        monstersFactory = new MonstersFactory();
        busterFactory = new BusterFactory();
    }

    public IInteractable? CreateRandom()
    {
        var probability = Random.Shared.Next(1, 100);

        return probability switch
        {
            > 0 and <= propabilityForMonstr => monstersFactory.CreateRandom(),
            > propabilityForMonstr and <= propabilityForBuster => busterFactory.CreateRandom(),
            _ => null,
        }; ;

        
    }

    
}
