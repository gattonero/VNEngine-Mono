using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace VNE
{
	public class Background
	{
		public Texture2D picture;
		public Vector2 position;
		public bool alive; // Identifer to visible background picture

		public Background (Texture2D loadedPicture)
		{
			position = Vector2.Zero;

			picture = loadedPicture;

			alive = false;
		}
	}
}

