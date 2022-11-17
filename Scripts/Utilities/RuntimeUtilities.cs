﻿using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlpacaIT.VertexTracer
{
    public class RuntimeUtilities
    {

        public static bool ReadLightmapData(int identifier, out uint[] pixels)
        {
            try
            {
                string scene = Path.GetFileNameWithoutExtension(SceneManager.GetActiveScene().path);

                var lightmap = Resources.Load<TextAsset>(scene + "-Lightmap" + identifier);
                if (lightmap == null)
                    Debug.LogError("Cannot find '" + scene + "-Lightmap" + identifier + ".bytes" + "'!");
                var byteArray = lightmap.bytes;

                using (var memory = new MemoryStream(byteArray))
                using (var decompressed = new MemoryStream())
                using (var gzip = new GZipStream(memory, CompressionMode.Decompress))
                {
                    gzip.CopyTo(decompressed);
                    gzip.Close();

                    byteArray = decompressed.ToArray();
                    Debug.Log(byteArray.Length);
                }

                uint[] uintArray = new uint[byteArray.Length / 4];
                Buffer.BlockCopy(byteArray, 0, uintArray, 0, byteArray.Length);
                pixels = uintArray;

                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                pixels = default;
                return false;
            }
        }
    }
}
