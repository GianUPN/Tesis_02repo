using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02
{
    class TesisSpriteFactory : iSpriteFactory
    {
        private Game1 game;

        public TesisSpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public Sprite obtenerSprite(String nombreSprite){

            Sprite objSprite = null;
            switch (nombreSprite)
            {
                case "pared":
                    objSprite = new Pared(game);
                    break;
            }
            return objSprite;
        }

        
        

    }
}
