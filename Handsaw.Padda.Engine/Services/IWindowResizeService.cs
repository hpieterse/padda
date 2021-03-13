using System;
using System.Drawing;

namespace Handsaw.Padda.Engine.Services
{
  internal interface IWindowResizeService {
    event Action<SizeF> OnWindowResize;
  }
    
}