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

    public CrystiXGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _gemFactory = new GemFactory(Content);
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

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Left))
            _gemCluster.MoveLeft();

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
            _gemCluster.MoveRight();

        // TODO: Add your update logic here
        _gemCluster.MoveDown();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _gemCluster.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
