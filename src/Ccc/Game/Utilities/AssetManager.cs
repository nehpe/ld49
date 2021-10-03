using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Ccc.Game.Utilities
{
    public static class AssetManager
    {
        public static Dictionary<String, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static void AddTexture(String name, Texture2D texture)
        {
            Textures.Add(name, texture);
        }

        public static Texture2D GetTexture(String name)
        {
            return Textures[name];
        }
    }
}