namespace Battle_Of_Tanks_Lib.GameObjects
{
    public abstract class GameObject
    {
        public Rectangle Position { get; set; }
        public bool IsSolid { get; protected set; } = false;
        public bool CanMove {  get; protected set; } = true;
        protected GameObject(Rectangle rectangle)
        {
            Position = rectangle;
        }

    }
}
