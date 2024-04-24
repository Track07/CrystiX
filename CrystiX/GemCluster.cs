namespace CrystiX;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GemCluster
{
    public Gem[] Gems { get; set; } = new Gem[3];
    
    public int Height => Settings.GemHeight*3;

    public Vector2 Position
    {
        get 
        {
            return Gems[0].Position;
        }
    }

    public GemCluster(Gem[] gems)
    {
        Gems = gems;
        SetPosition(Vector2.Zero);
    }

    public void Draw(SpriteBatch spriteBatch) 
    {
        foreach (var gem in Gems)
        {
            spriteBatch.Draw(gem.Texture, gem.Position, Color.White);
        }
    }

    public void MoveDown()
    {
        SetPosition(Position + new Vector2(0, 1));
    }

    public void MoveLeft()
    {
        if (Position.X < 0)
        {
            return;
        }

        SetPosition(Position - new Vector2(5, 0));
    }

    public void MoveRight()
    {
        if (Position.X > 400)
        {
            return;
        }

        SetPosition(Position + new Vector2(5, 0));
    }

    public void SetPosition(Vector2 position)
    {
        Gems[0].Position = position;
        Gems[1].Position = new Vector2(position.X, position.Y + Settings.GemHeight);
        Gems[2].Position = new Vector2(position.X, position.Y + 2*Settings.GemHeight);
    }
}
