public static class TelemetryBuffer
{
    static Dictionary<Type, int> numberTypePrefix = new()
    {
        {typeof(short), 254},
        {typeof(int), 252},
        {typeof(long), 248},
        {typeof(ushort), 2},
        {typeof(uint), 4},
    };

    public static byte[] ToBuffer(long reading)
    {
        var parsedNumber = reading switch
        {
            >= -32_768 and <= -1 => typeof(short),
            >= -2_147_483_648 and <= -32_769 or >= 65_536 and <= 2_147_483_647 => typeof(int),
            >= -9_223_372_036_854_775_808 and <= -2_147_483_649 or >= 4_294_967_296 and <= 9_223_372_036_854_775_807 => typeof(long),
            >= 0 and <= 65_535 => typeof(ushort),
            >= 2_147_483_648 and <= 4_294_967_295 => typeof(uint)
        };

        var defaultBuffer = new byte[8];
        var buffer = parsedNumber switch
        {
            var t when t == typeof(short) => BitConverter.GetBytes((short)reading),
            var t when t == typeof(int) => BitConverter.GetBytes((int)reading),
            var t when t == typeof(long) => BitConverter.GetBytes(reading),
            var t when t == typeof(ushort) => BitConverter.GetBytes((ushort)reading),
            var t when t == typeof(uint) => BitConverter.GetBytes((uint)reading),
            _ => BitConverter.GetBytes(reading)
        };
        Array.Copy(buffer, defaultBuffer, buffer.Length);
        return [(byte)numberTypePrefix[parsedNumber], .. defaultBuffer];
    }


    public static long FromBuffer(byte[] buffer)
    {
        int prefix = buffer[0];
        var bufferArray = new byte[8];
        Array.Copy(buffer, 1, bufferArray, 0, 8);
        if (numberTypePrefix.Any(x => x.Value == prefix))
        {
            Type numberType = numberTypePrefix.FirstOrDefault(x => x.Value == prefix).Key;
            return numberType switch
            {
                var t when t == typeof(short) => BitConverter.ToInt16(bufferArray),
                var t when t == typeof(int) => BitConverter.ToInt32(bufferArray),
                var t when t == typeof(long) => BitConverter.ToInt64(bufferArray),
                var t when t == typeof(ushort) => BitConverter.ToUInt16(bufferArray),
                var t when t == typeof(uint) => BitConverter.ToUInt32(bufferArray),
                _ => BitConverter.ToInt64(bufferArray)
            };
        }
        else { return 0; }
    }
}
