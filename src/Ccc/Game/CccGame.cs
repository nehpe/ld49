using System;
using Ccc.Game.Scenes;

namespace Ccc.Game
{
    public class CccGame : IDisposable
    {
        Renderer.Renderer r;
        IScene currentScene;


        public CccGame()
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            r = new Renderer.Renderer(screenWidth, screenHeight, "CCC");
            currentScene = new PlayScene(r, this);
        }


        public void Run()
        {
            while (!r.WindowShouldClose())
            {
                currentScene.Update();
                currentScene.Draw();
            }
        }

        public void Dispose()
        {
            r.CloseWindow();
            r = null;
        }
    }
}
