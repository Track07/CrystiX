using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrystiX;

public class CrystiXGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private GemFactory _gemFactory;
    private Gem[] gems = new Gem[20];

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

        for (int i = 0; i < gems.Length; i++)
        {
            gems[i] = _gemFactory.GetRandomGem();
        }

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        for (int i = 0; i < gems.Length; i++)
        {
            _spriteBatch.Draw(gems[i].Texture, new Vector2(0, 0 + i*25), Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
