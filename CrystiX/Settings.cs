namespace CrystiX;

public static class Settings
{
    public static int GemWidth => 25;
    public static int GemHeight => 25;

    public static int ArenaGemsX => 5;

    public static int ArenaGemsY => 13;

    public static int ArenaWidth => GemWidth*ArenaGemsX;

    public static int ArenaHeight => GemHeight*ArenaGemsY;
}
