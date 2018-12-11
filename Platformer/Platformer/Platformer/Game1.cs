using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Platformer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpritePack spritePack;

        Player player;
        Wall wall1;

        Camera playerCamera;
        //Liste des murs et des sols pour les collisions
        List<Wall> wallList = new List<Wall>();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spritePack = new SpritePack(GraphicsDevice, Content);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            player = new Player(GraphicsDevice, new Vector2(32, 32), 32, 32, Color.Red);
            playerCamera = new Camera(GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height);

            //Création de murs temporaires ofc
            wall1 = new Wall(new Vector2(0, 128));
            wallList.Add(wall1);
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update(gameTime,wallList);
            playerCamera.setCameraPosition(player.getPosition() - player.getOrigin() + new Vector2(player.getRotation()/90*32,0));


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            player.Draw(spriteBatch,playerCamera);
            wall1.Draw(spriteBatch, playerCamera);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
