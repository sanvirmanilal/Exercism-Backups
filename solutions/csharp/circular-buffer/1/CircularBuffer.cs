public class CircularBuffer<T>
{
    private Queue<T> _queue;

    public CircularBuffer(int capacity)
    {
        _queue = new Queue<T>(capacity);
    }

    public T Read() => _queue.TryDequeue(out T result) ? result : throw new InvalidOperationException();

    public void Write(T value)
    {
        if (_queue.Count < _queue.Capacity)
        {
            _queue.Enqueue(value);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Overwrite(T value)
    {
        if (_queue.Count == _queue.Capacity)
        {
            _queue.Dequeue();
        }

        Write(value);
    }

    public void Clear() => _queue.Clear();
}