using System;
using System.Threading.Tasks;

namespace Handsaw.Padda.Engine.Services
{
  internal interface IAnimationService
  {
    event Func<long, Task> OnAnimationFrame;
  }
}
