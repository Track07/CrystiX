namespace CrystiX;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;

public class GemArena
{
    public Vector2 Position => new Vector2(Settings.ArenaWidth, 0);

    public void Draw(SpriteBatch spriteBatch)
    {
        DrawLeftBound(spriteBatch);
        DrawRightBound(spriteBatch);
    }

    private void DrawLeftBound(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawLine(
            Position + new Vector2(-1, 0),
            Position + new Vector2(-1, Settings.ArenaHeight),
            Color.White);
    }

    private void DrawRightBound(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawLine(
            Position + new Vector2(Settings.ArenaWidth + 1, 0),
            Position + new Vector2(Settings.ArenaWidth + 1, Settings.ArenaHeight),
            Color.White);
    }
}
