﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;
using Tesis_02.Objetos;

namespace Tesis_02
{
    class Raz_mapa1_2_SpriteFactory:iSpriteFactory
    {

         private Game1 game;

         public Raz_mapa1_2_SpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public Sprite obtenerSprite(String nombreSprite){

            Sprite objSprite = null;
            switch (nombreSprite)
            {
                
                case "puerta":
                    objSprite = new Puerta(game);
                    break;

                case "portal01":
                    objSprite = new Portal01(game);
                    break;
            }
            return objSprite;
        }

    }
}
