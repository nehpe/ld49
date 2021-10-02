using Ccc.Game;

namespace Ccc.Game.Entities
{
    public interface IEntity
    {
        public void Draw();
        public void Update();
        public bool Dead();
    }

}
