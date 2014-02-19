#region File Description
//-----------------------------------------------------------------------------
// PongGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

#endregion
namespace Pong
{
	/// <summary>
	/// Default Project Template
	/// </summary>
	public class Game1 : Game
	{

		#region Fields

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Texture2D paddleTexture;
		Vector2 leftPaddlePosition, rightPaddlePosition; 

		Texture2D ballTexture;


		Vector2 ballPosition;
		Vector2 ballPosition1; 

		KeyboardState kb; 

		float paddleSpeed; 

		float ballSpeedX; 
		float ballSpeedY;

		 

		int player1Score, player2Score;

		SpriteFont UIFont;  

		Rectangle leftPaddleRectangle1, leftPaddleRectangle2, leftPaddleRectangle3, leftPaddleRectangle4, leftPaddleRectangle5,
		rightPaddleRectangle1, rightPaddleRectangle2, rightPaddleRectangle3, rightPaddleRectangle4, rightPaddleRectangle5, ballRectangle; 




		#endregion

		#region Initialization

		public Game1 ()
		{

			graphics = new GraphicsDeviceManager (this);
			
			Content.RootDirectory = "Content";

			graphics.IsFullScreen = false;
		}

		/// <summary>
		/// Overridden from the base Game.Initialize. Once the GraphicsDevice is setup,
		/// we'll use the viewport to initialize some values.
		/// </summary>
		protected override void Initialize ()
		{
			base.Initialize ();
		}

		/// <summary>
		/// Load your graphics content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be use to draw textures.
			paddleTexture = Content.Load<Texture2D> ("paddleTexture");
			ballTexture = Content.Load<Texture2D> ("ballTexture");
			UIFont = Content.Load<SpriteFont> ("UIFont");


			spriteBatch = new SpriteBatch (graphics.GraphicsDevice);

			paddleSpeed = 9f; 

			ballSpeedX = 5f; 
			ballSpeedY = 5f; 



			 

			leftPaddlePosition.X = 15; 
			leftPaddlePosition.Y = GraphicsDevice.Viewport.Height / 2 - paddleTexture.Height / 2; 

			rightPaddlePosition.X = GraphicsDevice.Viewport.Width - 15 - paddleTexture.Width; 
			rightPaddlePosition.Y = GraphicsDevice.Viewport.Height / 2 - paddleTexture.Height / 2; 

			ballPosition.Y = GraphicsDevice.Viewport.Width / 2 - ballTexture.Height / 2;
			ballPosition.X = GraphicsDevice.Viewport.Height / 2 - ballTexture.Width / 2;

		
			ballPosition1.Y = 280;
			ballPosition1.X = 120;  




			player1Score = 0;
			player2Score = 0;

			// TODO: use this.Content to load your game content here eg.

		}

		#endregion

		#region Update and Draw

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			kb = Keyboard.GetState ();

			if (kb.IsKeyDown (Keys.W))
		    {
				leftPaddlePosition.Y -= paddleSpeed; 
			}

			if (kb.IsKeyDown (Keys.S)) 
			{
				leftPaddlePosition.Y += paddleSpeed; 
			}


			leftPaddlePosition.Y = MathHelper.Clamp (leftPaddlePosition.Y, 0, GraphicsDevice.Viewport.Height - paddleTexture.Height);

			if (kb.IsKeyDown (Keys.O))
		    {
				rightPaddlePosition.Y -= paddleSpeed;
			}

			if (kb.IsKeyDown (Keys.L)) 
			{
				rightPaddlePosition.Y += paddleSpeed;
			}

			rightPaddlePosition.Y = MathHelper.Clamp (rightPaddlePosition.Y, 0, GraphicsDevice.Viewport.Height - paddleTexture.Height); 



			if (ballPosition.Y <= 0 || ballPosition.Y >= GraphicsDevice.Viewport.Height - ballTexture.Height)
			{
				ballSpeedY = -ballSpeedY;
			}

			leftPaddleRectangle1 = new Rectangle ((int)leftPaddlePosition.X, (int)leftPaddlePosition.Y, paddleTexture.Width, paddleTexture.Height / 5);
			rightPaddleRectangle1 = new Rectangle ((int)rightPaddlePosition.X, (int)rightPaddlePosition.Y, paddleTexture.Width, paddleTexture.Height / 5); 

			leftPaddleRectangle2 = new Rectangle ((int)leftPaddlePosition.X, (int)leftPaddlePosition.Y + (paddleTexture.Height / 5) * 2, paddleTexture.Width, paddleTexture.Height / 5);  
			rightPaddleRectangle2 = new Rectangle ((int)rightPaddlePosition.X, (int)rightPaddlePosition.Y + (paddleTexture.Height / 5) * 2, paddleTexture.Width, paddleTexture.Height / 5);  

			leftPaddleRectangle3 = new Rectangle ((int)leftPaddlePosition.X, (int)leftPaddlePosition.Y + (paddleTexture.Height / 5) * 3, paddleTexture.Width, paddleTexture.Height / 5); 
			rightPaddleRectangle3 = new Rectangle ((int)rightPaddlePosition.X, (int)rightPaddlePosition.Y + (paddleTexture.Height / 5) * 3, paddleTexture.Width, paddleTexture.Height / 5); 

			leftPaddleRectangle4 = new Rectangle ((int)leftPaddlePosition.X, (int)leftPaddlePosition.Y + (paddleTexture.Height / 5) * 4, paddleTexture.Width, paddleTexture.Height / 5); 
			rightPaddleRectangle4 = new Rectangle ((int)rightPaddlePosition.X, (int)rightPaddlePosition.Y + (paddleTexture.Height / 5) * 4, paddleTexture.Width, paddleTexture.Height / 5); 

			leftPaddleRectangle5 = new Rectangle ((int)leftPaddlePosition.X, (int)leftPaddlePosition.Y + (paddleTexture.Height / 5) * 5, paddleTexture.Width, paddleTexture.Height / 5); 
			rightPaddleRectangle5 = new Rectangle ((int)rightPaddlePosition.X, (int)rightPaddlePosition.Y + (paddleTexture.Height / 5) * 5, paddleTexture.Width, paddleTexture.Height / 5); 


			ballRectangle = new Rectangle ((int)ballPosition.X, (int)ballPosition.Y, ballTexture.Width, ballTexture.Height);
			//ballRectangle2 = new Rectangle ((int)ballPosition2.X (int)ballPosition2.Y, ballTexture2.Width, ballTexture2.Height);  


			if (ballRectangle.Intersects (leftPaddleRectangle1) || ballRectangle.Intersects (leftPaddleRectangle5))
		    {
				ballSpeedX = -ballSpeedX + 20;
				//ballSpeedY -=  10; 

			}

			if (ballRectangle.Intersects (leftPaddleRectangle2) || ballRectangle.Intersects (leftPaddleRectangle4))
			{
				ballSpeedX = -ballSpeedX + 10;
				//ballSpeedY -=  5; 
			}

			if (ballRectangle.Intersects (leftPaddleRectangle3)) 
			{
				ballSpeedX = -ballSpeedX + 5; 
				//ballSpeedY -= ballSpeedY; 
			}

			if (ballRectangle.Intersects (rightPaddleRectangle1) || ballRectangle.Intersects (rightPaddleRectangle5))
			{
				ballSpeedX = -ballSpeedX - 20;
				//ballSpeedY += 10; 
			}

			if (ballRectangle.Intersects (rightPaddleRectangle2) || ballRectangle.Intersects (rightPaddleRectangle4))
			{
				ballSpeedX = -ballSpeedX - 10; 
				//ballSpeedY -= 5;
			}

			if (ballRectangle.Intersects (rightPaddleRectangle3)) 
			{
				ballSpeedX = -ballSpeedX - 5 ;
				//ballSpeedY -= ballSpeedY; 
			}
		       

			if (ballPosition.X < 0 || ballPosition.X < 0 ) 
			{
				player2Score++;

				ballPosition.X = (GraphicsDevice.Viewport.Width + ballTexture.Width) / 2;
				ballPosition.Y = (GraphicsDevice.Viewport.Height - ballTexture.Height) / 2; 

			



				ballSpeedX = 5f;

			}

			if (ballPosition.X > GraphicsDevice.Viewport.Width)
			{
				player1Score++;
				ballPosition.X = (GraphicsDevice.Viewport.Width + ballTexture.Width) / 2;
				ballPosition.Y = (GraphicsDevice.Viewport.Height - ballTexture.Height) / 2; 


				ballSpeedX = 5f;
				ballSpeedX = 5f; 
			}

			ballPosition.X += ballSpeedX;
			ballPosition.Y += ballSpeedY;

		

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself. 
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			// Clear the backbuffer
			graphics.GraphicsDevice.Clear (Color.Black);


			spriteBatch.Begin ();

			spriteBatch.Draw (paddleTexture, leftPaddlePosition, Color.White);
			spriteBatch.Draw (paddleTexture, rightPaddlePosition, Color.White);
			spriteBatch.Draw (ballTexture, ballPosition, Color.White); 
			spriteBatch.DrawString (UIFont, "" + player1Score, new Vector2 (80, 30), Color.White);
			spriteBatch.DrawString (UIFont, "" + player2Score, new Vector2 (GraphicsDevice.Viewport.Width - 95, 30), Color.White); 

		

		
			// draw the logo
			//spriteBatch.Draw (logoTexture, new Vector2 (130, 200), Color.White);

			spriteBatch.End ();

			//TODO: Add your drawing code here
			base.Draw (gameTime);
		}

		#endregion

	}
}
