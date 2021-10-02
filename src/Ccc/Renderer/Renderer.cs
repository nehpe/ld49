using System.Numerics;
using Raylib_cs;
using rl = Raylib_cs.Raylib;

namespace Ccc.Renderer
{
    public class Renderer
    {
        public Renderer(int screenWidth, int screenHeight, string title)
        {
            rl.InitWindow(screenWidth, screenHeight, title);
            rl.InitAudioDevice();
            rl.SetExitKey(KeyboardKey.KEY_Q);

            this._setupHinting();
        }

        private void _setupHinting()
        {
            /*
            rl.SetConfigFlags(ConfigFlag.FLAG_MSAA_4X_HINT);
            rl.SetConfigFlags(ConfigFlag.FLAG_VSYNC_HINT);
            rl.SetConfigFlags(ConfigFlag.FLAG_WINDOW_UNDECORATED);
            */
        }

        public bool WindowShouldClose() => rl.WindowShouldClose();
        public float GetFrameTime() => rl.GetFrameTime();
        public void ClearBackground(Color color) => rl.ClearBackground(color);
        public void CloseWindow() => rl.CloseWindow();

        public void BeginDrawing() => rl.BeginDrawing();
        public void EndDrawing() => rl.EndDrawing();

        public void DrawFPS(int x, int y) => rl.DrawFPS(x, y);

        // Keyboard
        public void IsKeyPressed(KeyboardKey k) => rl.IsKeyPressed(k);
        public void IsKeyDown(KeyboardKey k) => rl.IsKeyDown(k);
        public void IsKeyReleased(KeyboardKey k) => rl.IsKeyReleased(k);
        public void IsKeyUp(KeyboardKey k) => rl.IsKeyUp(k);

        // Mouse
        public bool IsMouseButtonPressed(MouseButton mb) => rl.IsMouseButtonPressed(mb);
        public float GetMouseWheelMove() => rl.GetMouseWheelMove();
        public Vector2 GetMousePosition() => rl.GetMousePosition();

        // Fonts / text
        public Font LoadFont(string n) => rl.LoadFont(n);
        public int MeasureText(string v, int fontSize) => rl.MeasureText(v, fontSize);

        public void DrawText(string v, int x, int y, int s, Color c) => rl.DrawText(v, x, y, s, c);

        // Textures
        public Texture2D LoadTexture(string v) => rl.LoadTexture(v);
        public Texture2D LoadTextureFromImage(Image img) => rl.LoadTextureFromImage(img);
        public RenderTexture2D LoadRenderTexture(int w, int h) => rl.LoadRenderTexture(w, h);
        public void BeginTextureMode(RenderTexture2D t) => rl.BeginTextureMode(t);
        public void EndTextureMode() => rl.EndTextureMode();
        public void DrawTexture(Texture2D t, int x, int y, Color tint) => rl.DrawTexture(t, x, y, tint);
        public void DrawTexture(Texture2D t, Vector2 p, Color c) => rl.DrawTextureV(t, p, c);
        public void DrawTexture(Texture2D t, Vector2 p, float r, float s, Color ti) => rl.DrawTextureEx(t, p, r, s, ti);
        public void DrawTexture(Texture2D t, Rectangle s, Vector2 p, Color ti) => rl.DrawTextureRec(t, s, p, ti);
        public void DrawTexture(Texture2D t, Vector2 til, Vector2 o, Rectangle q, Color ti) => rl.DrawTextureQuad(t, til, o, q, ti);
        public void DrawTexture(Texture2D t, Rectangle s, Rectangle d, Vector2 o, float r, Color ti) => rl.DrawTexturePro(t, s, d, o, r, ti);
    }
}
