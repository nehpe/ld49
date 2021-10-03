using Ccc.Game;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public interface IEntity
    {
        public void Draw();
        public void Update();
        public bool Dead();
        public Rectangle GetRect();
    }

}
