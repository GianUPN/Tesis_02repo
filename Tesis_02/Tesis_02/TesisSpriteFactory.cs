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

        public Core.Sprite obtenerSprite(String nombreSprite){

            Core.Sprite objSprite = null;
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
