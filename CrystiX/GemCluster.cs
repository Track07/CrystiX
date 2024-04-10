namespace CrystiX;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GemCluster
{
    private Gem[] _gems = new Gem[3];

    public Vector2 Position
    {
        get 
        {
            return _gems[0].Position;
        }
    }

    public GemCluster(Gem[] gems)
    {
        _gems = gems;
        SetPosition(Vector2.Zero);
    }

    public void Draw(SpriteBatch spriteBatch) 
    {
        foreach (var gem in _gems)
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
        _gems[0].Position = position;
        _gems[1].Position = new Vector2(position.X, position.Y + Settings.GemHeight);
        _gems[2].Position = new Vector2(position.X, position.Y + 2*Settings.GemHeight);
    }
}
