#region Using Statements
using System;
using System.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace VNE
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		//Rectangle viewportRect;
		XmlTextReader ListOfCharacter;
		XmlTextReader Text;
		Replica replicas;

		MouseState mouse;
		MouseState mousePrev = Mouse.GetState ();
		KeyboardState kb;

		Interface panel;
		Interface menuButton;

		private	int hide;
		Background[] bg;
		private int numOfBg = 2; // Number of backgrounds
		// numOfBg = NumbersBackgrounds - 1
		private int slide = 0; // For backgrounds


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";	    
			graphics.PreferredBackBufferWidth = 800;        
			graphics.PreferredBackBufferHeight = 600;
			graphics.IsFullScreen = false; // Каким-то фигом неполноэкранная версия не хотет работать как надо
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			base.Initialize();

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);


			// Load interface
			panel = new Interface (Content.Load<Texture2D> ("Interface\\TextMenu"));
			panel.position = new Vector2 (0, 450);
			menuButton = new Interface (Content.Load<Texture2D> ("Interface\\MainMenuButton"));
			menuButton.position = new Vector2 (545, 110);
			// Backgrounds
			bg = new Background[numOfBg];
			// Load backgrounds
			for (int i = 0; i < numOfBg; i++) {
				bg [i] = new Background (Content.Load<Texture2D> ("Background\\" + i));
				bg [0].alive = true;
			}

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			mouse = Mouse.GetState ();
			kb = Keyboard.GetState ();
			hide = 250;
			// Exit from game
			if (kb.IsKeyDown (Keys.Q)) {
				Exit ();
			}

			if ((mousePrev.LeftButton != ButtonState.Pressed) && (mouse.LeftButton == ButtonState.Pressed)) {
				for (int i = 0; i < hide; hide -= 5)
					bg [slide].alive = false;
				slide += 1;
				bg [slide].alive = true;
				for (int i = 250; hide < i; hide += 5);
			}	
			mousePrev = mouse;
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin ();

			// Background
			foreach (Background x in bg) {
				if (x.alive) {
					spriteBatch.Draw (x.picture, x.position, new Color(1.0f,1.0f,1.0f,hide));
				}
			}
			spriteBatch.Draw (panel.texture, panel.position, new Color(0.6f,0.6f,0.6f,0.6f));
			spriteBatch.Draw (menuButton.texture, menuButton.position, new Color(0.7f,0.7f,0.7f,0.7f));
			spriteBatch.End ();

			base.Draw(gameTime);
		}
	}
}

