namespace CrystiX;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System.Collections.Generic;

public class GemArena
{
    private GemFactory _gemFactory;

    public Vector2 Position => new Vector2(Settings.ArenaWidth, 0);

    public List<Gem> Gems { get; set; } = new List<Gem>();

    public GemArena(GemFactory gemFactory)
    {
        _gemFactory = gemFactory;
    }

    public GemCluster SpawnCluster()
    {
        var gemCluster = _gemFactory.GetRandomGemCluster();
        gemCluster.SetPosition(this.Position + new Vector2(2*Settings.GemWidth,0));

        return gemCluster;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        DrawLeftBound(spriteBatch);
        DrawRightBound(spriteBatch);
        DrawGems(spriteBatch);
    }


    public void AddCluster(GemCluster gemCluster)
    {
        foreach (var gem in gemCluster.Gems)
        {
            Gems.Add(gem);
        }
    }

    public bool CanMove(GemCluster gemCluster)
    {
        if (gemCluster.Position.Y + gemCluster.Height >= Settings.ArenaHeight)
        {
            return false;
        }

        return true;
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

    private void DrawGems(SpriteBatch spriteBatch)
    {
        foreach (var gem in Gems)
        {
            spriteBatch.Draw(gem.Texture, gem.Position, Color.White);
        }
    }
}
