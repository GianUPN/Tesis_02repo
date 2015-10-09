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
        KeyboardState keyboardStateActual;
        KeyboardState keyboardStatePrevio;
        public Diamond personaje  { get; set; }
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
            personaje = new Diamond(this);
            Texture2D fondo = Content.Load<Texture2D>("Backgrounds/fondo");
            escenario = new TileMap(this, "Content/mapa_1-1.csv", personaje,2,10);
            escenario.spriteFactory = new TesisSpriteFactory(this);
            escenario.regenerarMapa();
            escenario.HorizontalScrolling = TileMap.Scrolling.Sprite;
            escenario.VerticalScrolling = TileMap.Scrolling.Sprite;
            
            escenario.ParallaxBackground = fondo;

            //Configurar el fondo del escenario
            //escenario.ParallaxBackgroundHorizontalScrolling = TileMap.ParallaxBackgroundScrolling.Normal;
            //escenario.ParallaxBackgroundVerticalScrolling = TileMap.ParallaxBackgroundScrolling.Normal;

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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            keyboardStatePrevio = keyboardStateActual;// Almacena el estado previo en variables distintas
            keyboardStateActual = Keyboard.GetState();// Leer el estado actual del teclado y almacenarlo
            

            personaje.velocidadX = 0;
            personaje.velocidadY = 0;
            /*
            bool correr = false;
            if (keyboardStateActual.IsKeyDown(Keys.LeftControl)){
                    correr = true;
            }*/

            if (keyboardStateActual.IsKeyDown(Keys.Down))
            {
                personaje.direccion = Diamond.Direccion.Abajo;
                personaje.velocidadY = +personaje.velocidad;
            }
            if (keyboardStateActual.IsKeyDown(Keys.Left))
            {
                personaje.direccion = Diamond.Direccion.Izquierda;
                personaje.velocidadX = -personaje.velocidad;
            }
            if (keyboardStateActual.IsKeyDown(Keys.Right))
            {
                personaje.direccion = Diamond.Direccion.Derecha;
                personaje.velocidadX = +personaje.velocidad;
            }
            if (keyboardStateActual.IsKeyDown(Keys.Up))
            {
                personaje.direccion = Diamond.Direccion.Arriba;
                personaje.velocidadY = -personaje.velocidad;
            }


            //actualizar estados de personaje
            if (personaje.velocidadX != 0 || personaje.velocidadY != 0)
            {
                personaje.estado = Diamond.Estado.Caminando;
            }
            else
            {
                personaje.estado = Diamond.Estado.Parado;
            }
            escenario.actualizar(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            escenario.dibujar(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
