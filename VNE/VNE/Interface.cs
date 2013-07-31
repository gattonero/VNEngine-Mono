using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;


namespace VNE
{
	public class Interface
	{
		public Texture2D texture;
		public Vector2 position;
		public Vector2 center;
		public bool visible;

		public Interface (Texture2D loadedTexture)
		{
			position = Vector2.Zero;

			texture = loadedTexture;

			center = new Vector2 (texture.Width / 2, texture.Height / 2);

			visible = true;		 
		}
	}
}

