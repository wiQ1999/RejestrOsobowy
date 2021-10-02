namespace Serializer.Interfaces
{
    public interface ISerialize<T>
    {
        void Serialize(T list);
    }
}
