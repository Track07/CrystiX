using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrystiX;

public class CrystiXGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private GemFactory _gemFactory;
    private GemCluster _gemCluster;
    private GemArena _gemArena;

    public CrystiXGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = Settings.ArenaWidth*3;
        _graphics.PreferredBackBufferHeight = Settings.ArenaHeight;

        _gemFactory = new GemFactory(Content);
        _gemArena = new GemArena();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _gemCluster = _gemFactory.GetRandomGemCluster();
        _gemCluster.SetPosition(_gemArena.Position + new Vector2(2*Settings.GemWidth,0));

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            if (_gemCluster.Position.X > _gemArena.Position.X)
            {
                _gemCluster.MoveLeft();
            }
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            if (_gemCluster.Position.X < _gemArena.Position.X + Settings.ArenaWidth - Settings.GemWidth)
            {
                _gemCluster.MoveRight();
            }
        }

        // TODO: Add your update logic here
        _gemCluster.MoveDown();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _gemArena.Draw(_spriteBatch);
        _gemCluster.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
