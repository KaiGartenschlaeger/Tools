using System;
using System.IO;
using System.IO.Compression;

namespace Tools.Helper
{
    /// <summary>
    /// Stellt Hilfsmethoden zum komprimieren- /dekomprimieren zur Verfügung.
    /// </summary>
    public static class CompressHelper
    {
        /// <summary>
        /// Komprimiert ein Array mit den GZIP-Algorithmus.
        /// </summary>
        /// <param name="data">Array das komprimiert werden soll.</param>
        public static byte[] GZIPCompress(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            byte[] result = null;
            using (MemoryStream mem = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(mem, CompressionMode.Compress, true))
                {
                    gzip.Write(data, 0, data.Length);
                }

                result = mem.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Dekomprimiert ein zuvor mit den GZIP-Algorithmus komprimiertes Array.
        /// </summary>
        /// <param name="compressedData">Array das die zuvor komprimierten Daten enthält.</param>
        public static byte[] GZIPDecompress(byte[] compressedData)
        {
            if (compressedData == null || compressedData.Length == 0)
            {
                throw new ArgumentNullException("compressedData");
            }

            byte[] result = null;
            using (MemoryStream mem = new MemoryStream(compressedData))
            {
                using (GZipStream stream = new GZipStream(mem, CompressionMode.Decompress))
                {
                    const int size = 4096;
                    byte[] buffer = new byte[4096];

                    using (MemoryStream mem_result = new MemoryStream())
                    {
                        int count = 0;

                        do
                        {
                            count = stream.Read(buffer, 0, size);
                            if (count > 0)
                            {
                                mem_result.Write(buffer, 0, count);
                            }
                        }
                        while (count > 0);

                        result = mem_result.ToArray();
                    }
                }
            }

            return result;
        }
    }
}