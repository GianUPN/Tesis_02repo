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
            /*escenario = new TileMap(this,"",personaje,5,13);
            escenario.spriteFactory = new TesisSpriteFactory(this);
            escenario.regenerarMapa();
            escenario.HorizontalScrolling = TileMap.Scrolling.Sprite;
            escenario.VerticalScrolling = TileMap.Scrolling.Sprite;*/
            
            escenario.ParallaxBackground = fondo;
            //Configurar el fondo del escenario
            escenario.ParallaxBackgroundHorizontalScrolling = TileMap.ParallaxBackgroundScrolling.Normal;
            escenario.ParallaxBackgroundVerticalScrolling = TileMap.ParallaxBackgroundScrolling.Normal;

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

                if (keyboardStateActual.IsKeyDown(Keys.C) && !keyboardStatePrevio.IsKeyDown(Keys.C) && soldado.estado != Aquiles.Estado.Muriendo)
                {
                    soldado.disparar();
                }

                bool correr = false;
                if (keyboardStateActual.IsKeyDown(Keys.LeftControl) && soldado.estado != Aquiles.Estado.Muriendo)
                {
                    correr = true;
                }

                if (keyboardStateActual.IsKeyDown(Keys.Down) && !keyboardStatePrevio.IsKeyDown(Keys.Down) && soldado.estado != Aquiles.Estado.Muriendo)
                {
                    soldado.agacharse();
                }

                soldado.velocidadX = 0;
                if (keyboardStateActual.IsKeyDown(Keys.Left) && soldado.estado != Aquiles.Estado.Muriendo)
                {
                    soldado.direccion = Aquiles.Direccion.Izquierda;
                    //if (soldado.estado != Aquiles.Estado.Agachado) {
                    soldado.velocidadX = -soldado.velocidad;
                    //}
                    if (correr)
                    {
                        soldado.velocidadX -= 0.1f;
                    }
                }
                if (keyboardStateActual.IsKeyDown(Keys.Right) && soldado.estado != Aquiles.Estado.Muriendo)
                {
                    soldado.direccion = Aquiles.Direccion.Derecha;
                    //if (soldado.estado != Aquiles.Estado.Agachado){
                    soldado.velocidadX = +soldado.velocidad;
                    //}
                    if (correr)
                    {
                        soldado.velocidadX += 0.1f;
                    }
                }

                if (keyboardStateActual.IsKeyDown(Keys.Space) && !keyboardStatePrevio.IsKeyDown(Keys.Space) && soldado.estado != Aquiles.Estado.Muriendo && soldado.estado != Aquiles.Estado.Agachado)
                {
                    soldado.saltar();
                }

                //actualizar estados de aquiles
                if (soldado.estado != Aquiles.Estado.Saltando && soldado.estado != Aquiles.Estado.Agachado)
                {
                    if (soldado.velocidadX != 0)
                    {
                        soldado.estado = Aquiles.Estado.Caminando;
                    }
                    else
                    {
                        soldado.estado = Aquiles.Estado.Parado;
                    }
                }
                if (!keyboardStateActual.IsKeyDown(Keys.Down))
                {
                    if (soldado.estado != Aquiles.Estado.Saltando && soldado.estado != Aquiles.Estado.Muriendo && soldado.estado != Aquiles.Estado.Caminando)
                    {
                        soldado.estado = Aquiles.Estado.Parado;
                    }
                }
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
