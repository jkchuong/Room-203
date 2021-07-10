namespace Inventory
{
    public enum QuestProgression
    {
        // Store things that you want to have different dialogue
        Default, // The default thing. GameManager should always have this.
        
        // Plate 1
        Drawer,
        Plate1,
        
        // Plate 2
        EnteredSecondRoom1,
        FoundLightbulb,
        EnteredSecondRoom2,
        Plate2,

        // Plate 3
        WindowEvent1,
        FoundLetter,
        MovedLamp,
        FoundCoin,
        WindowEvent2,
        Plate3,

        // Plate 4
        FoundLocket,
        FoundDress,
        
        
        // Key
    }
}