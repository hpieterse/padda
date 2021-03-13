using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Handsaw.Padda.Engine.Models;
using Microsoft.AspNetCore.Components;

namespace Handsaw.Padda.Engine.Services
{
  internal interface ICanvasService
  {
    SizeF Size { get; }

    Task Setup(ElementReference canvas);

    Task<Guid> LoadImage(string src);

    Task<PointF> SetSize(ElementReference canvas, SizeF size);

    Task<PointF> SetSizeUnmarshalled(Guid canvasId, SizeF size);

    Task Clear(ElementReference canvas);

    Task ClearUnmarshalled(Guid canvasId);

    Task Draw(ElementReference canvas, IEnumerable<DrawOperationDetail> drawOperations);

    Task DrawUnmarshalled(Guid canvasId, IEnumerable<DrawOperationDetail> drawOperations);
  }
}

