public interface IPotion
{
    public enum PotionType
    {
        Vacuum,
        Grow,
        Shrink,
        InverseGravity
    }
    
    public enum CollisionType
    {
        Point,
        Splash,
        Bounce,
    }
}
