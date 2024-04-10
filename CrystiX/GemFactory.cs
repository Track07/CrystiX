namespace CrystiX
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class GemFactory
    {
        private ContentManager m_contentManager;

        private string[] m_textures = new string[] { "BlueGem25", "GreenGem25", "PurpleGem25", "YellowGem25" };


        public GemFactory(ContentManager contentManager)
        {
            m_contentManager = contentManager;
        }

        public Gem GetRandomGem()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 4);


            return new Gem { Texture = m_contentManager.Load<Texture2D>(m_textures[randomNumber]) };
        }

        public GemCluster GetRandomGemCluster()
        {
            return new GemCluster(new[] { GetRandomGem(), GetRandomGem(), GetRandomGem() });
        }

    }
}
