using System.Numerics;
using Ccc.Game.Entities;
using Raylib_cs;

namespace Ccc.Game.HUD
{
    public class Hud
    {
        Bloodometer blood;
        
        Renderer.Renderer r;
        public Hud(Renderer.Renderer r)
        {
            this.r = r;
            blood = new Bloodometer(this.r);
        }

        public void Draw()
        {
            blood.Draw();
        }

        public void Update()
        {
            blood.Update();
        }
    }
}