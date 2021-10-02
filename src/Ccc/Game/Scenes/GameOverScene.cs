using Raylib_cs;
using System.Numerics;

namespace Ccc.Game.Scenes
{
    public class GameOverScene : IScene
    {
        Renderer.Renderer r;
        CccGame g;

        string GameOverString = "Game Over Man";

        int FontSize = 28;

        Vector2 position;

        public GameOverScene(Renderer.Renderer r, CccGame g)
        {
            this.r = r;
            this.g = g;

            var measureText = r.MeasureText(GameOverString, FontSize);

            position = new Vector2(
                    (CccSettings.SCREEN_WIDTH / 2) - (measureText / 2),
                    (CccSettings.SCREEN_HEIGHT / 2) - (FontSize / 2)
                    );
        }

        public void Draw()
        {
            r.ClearBackground(Color.BLACK);
            r.BeginDrawing();
            {
                r.DrawText(
                        "Game Over Man",
                        (int)position.X, (int)position.Y,
                        FontSize, Color.WHITE);
                r.DrawFPS(10, 10);
            }
            r.EndDrawing();
        }

        public void Update()
        {

        }
    }
}
