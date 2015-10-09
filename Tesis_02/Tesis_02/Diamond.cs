using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using Tesis_02;

namespace Tesis_02
{
    class Diamond : Core.Sprite
    {
        private float fuerzaGravedad = 0.002f;
        public float velocidad { get; set; }
        public enum Direccion { Izquierda, Derecha };
        public Direccion direccion { get; set; }
        public enum Estado { Caminando, Parado};





    }
}
