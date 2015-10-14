using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tesis_02.Core;

namespace Tesis_02
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TileMap escenario;
        public PersonajePrincipal personaje  { get; set; }
        //public Texture2D fondo { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            personaje = new PersonajePrincipal(this);
            Texture2D fondo = Content.Load<Texture2D>("Backgrounds/fondo");
            escenario = new TileMap(this, "Content/Mapas/mapa_1-1.csv", personaje,2,10);
            escenario.spriteFactory = new TesisSpriteFactory(this);
            //escenario.regenerarMapa();
            TileMap.Instance.regenerarMapa();
            escenario.HorizontalScrolling = TileMap.Scrolling.Sprite;
            escenario.VerticalScrolling = TileMap.Scrolling.Sprite;
            
            escenario.ParallaxBackground = fondo;

           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
               // this.Exit();

            Keyboard1.Instance.setkeyboardStatePrevio(Keyboard1.Instance.getkeyboardStateActual);
            // Almacena el estado previo en variables distintas
            Keyboard1.Instance.setkeyboardStateActual(Keyboard.GetState());
            // Leer el estado actual del teclado y almacenarlo
            /*
            if (Keyboard1.Instance.getkeyboardStateActual.IsKeyDown(Keys.Escape))
            {
                escenario = new TileMap(this, "Content/Mapas/mapa_1-1.csv", personaje, 2, 10);

                TileMap.Instance.regenerarMapa();
            }
            */
            personaje.parar_personaje();
            personaje.actualizar_teclas();
            escenario.actualizar(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            escenario.dibujar(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
