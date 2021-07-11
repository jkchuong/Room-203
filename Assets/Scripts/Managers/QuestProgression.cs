namespace Managers
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
        WalkedOverCarpet,
        Plate2,

        // Plate 3
        WindowEvent1,
        FoundLetter,
        MovedLamp,
        FoundCoin,
        WindowEvent2,
        FoundNewspaper,
        Plate3,

        // Plate 4
        FoundLocket,
        SearchedBookcase,
        FoundMagazine,
        FoundDress,
        Plate4,
        
        // Key
        FoundRecord,
        PlayedRecord,
        FoundPhone,
        FoundMovieTicket,
        OpenedSafe,
        Key
    }
}