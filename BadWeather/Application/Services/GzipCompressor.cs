using System.IO.Compression;

namespace BadWeather.Application.Services;

public class GzipCompressor
{
    public Stream DecompressStream(Stream compressedStream)
    {
        return new GZipStream(compressedStream, CompressionMode.Decompress);
    }
}