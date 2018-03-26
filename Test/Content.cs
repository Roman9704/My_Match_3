using System.Collections.Generic;

using SFML.Graphics;

namespace Test
{
    class Content
    {
        public const string CONTENT_DIR = "Content\\";

        public static Texture textures = null;

        public static List<Sprite> ElementSprite = null;
        public static Sprite SelectSprite = null;
        public static Sprite ButtonSprite0 = null;
        public static Sprite ButtonSprite1 = null;
        public static Sprite ButtonOkSprite = null;
        public static Sprite ButtonOkSelectSprite = null;

        public static Font font;

        public static void Load()
        {
            textures = new Texture(CONTENT_DIR + "Textures\\Texture.png");
            ElementSprite = new List<Sprite>();
            int i;
            for (i = 0; i < 6; i++)
            {
                ElementSprite.Add(new Sprite(textures, new IntRect(i * 60 + i, 0, 60, 60)));
            }
            SelectSprite = new Sprite(textures, new IntRect(i * 60 + i, 0, 60, 60)); 
            ButtonSprite0 = new Sprite(textures, new IntRect(427, 0, 120, 60));
            ButtonSprite1 = new Sprite(textures, new IntRect(548, 0, 120, 60));
            ButtonOkSprite = new Sprite(textures, new IntRect(669, 0, 60, 60));
            ButtonOkSelectSprite = new Sprite(textures, new IntRect(730, 0, 60, 60));

            font = new Font(CONTENT_DIR + "Fonts\\Amsdamcyr-lat.ttf");
        }
    }
}