using System.Collections.Generic;

using SFML.Graphics;

namespace Test
{
    static class Content
    {
        public const string ContentDir = "Content\\";

        public static Texture Textures = null;

        public static List<Sprite> ElementSprite = null;
        public static List<Color> ListOfColors = null;

        public static Sprite SelectSprite = null;
        public static Sprite ButtonSprite0 = null;
        public static Sprite ButtonSprite1 = null;
        public static Sprite ButtonOkSprite = null;
        public static Sprite ButtonOkSelectSprite = null;

        public static Font Font;

        public static void Load()
        {
            Textures = new Texture(ContentDir + "Textures\\Texture.png");

            ElementSprite = new List<Sprite>();
            int i;
            for (i = 0; i < 6; i++)
            {
                ElementSprite.Add(new Sprite(Textures, new IntRect(i * 60 + i, 0, 60, 60)));
            }
            SelectSprite = new Sprite(Textures, new IntRect(i * 60 + i, 0, 60, 60)); 
            ButtonSprite0 = new Sprite(Textures, new IntRect(427, 0, 120, 60));
            ButtonSprite1 = new Sprite(Textures, new IntRect(548, 0, 120, 60));
            ButtonOkSprite = new Sprite(Textures, new IntRect(669, 0, 60, 60));
            ButtonOkSelectSprite = new Sprite(Textures, new IntRect(730, 0, 60, 60));

            Font = new Font(ContentDir + "Fonts\\Amsdamcyr-lat.ttf");

            ListOfColors = new List<Color>();
            ListOfColors.Add(new Color(48, 10, 36));    // DarkPurple
            ListOfColors.Add(new Color(207, 245, 219)); // Turquoise
        }
    }
}