using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMeatBoyPC.Core
{
    public interface iSpriteFactory
    {
        Sprite obtenerSprite(String nombreSprite);
    }
}
