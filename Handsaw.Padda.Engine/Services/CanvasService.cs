using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Handsaw.Padda.Engine.Models;
using Handsaw.Padda.Engine.InteropStructs;
using System.Linq;

namespace Handsaw.Padda.Engine.Services
{
  internal class CanvasService : UnmarshalledInteropServiceBase, ICanvasService
  {

    public CanvasService(IInteropLoadService loadService) : base(loadService, "_content/Handsaw.Padda.Engine/canvasInterop.js")
    {
    }

    public async Task Setup(ElementReference canvas)
    {
      var module = await Module.Value;
      await module.InvokeVoidAsync("setup", canvas);
    }

    private SizeF _size;
    public SizeF Size { get { return _size; } }

    public async Task<PointF> SetSize(ElementReference canvas, SizeF size)
    {
      var module = await Module.Value;
      var position =  await module.InvokeAsync<string>("setSize", canvas, size.Width, size.Height);
      _size = size;

      var positionX = float.Parse(position.Split(",")[0]);
      var positionY = float.Parse(position.Split(",")[1]);

      return new PointF(positionX, positionY);
    }

    public async Task<PointF> SetSizeUnmarshalled(Guid canvasId, SizeF size)
    {
      var module = await Module.Value;

      var position =  module.InvokeUnmarshalled<SetSizeStruct, string>("setSizeUnmarshalled", new SetSizeStruct() {
        Width = size.Width,
        Height = size.Height,
        CanvasId = canvasId.ToString()
      });

      _size = size;

      var positionX = float.Parse(position.Split(",")[0]);
      var positionY = float.Parse(position.Split(",")[1]);

      return new PointF(positionX, positionY);
    }

    private IDictionary<Guid, TaskCompletionSource<Guid>> _imageLoadTasks = new Dictionary<Guid, TaskCompletionSource<Guid>>();

    public async Task<Guid> LoadImage(string src)
    {
      var imageId = Guid.NewGuid();
      var module = await Module.Value;
      var serviceReference = DotNetObjectReference.Create(this);
      await module.InvokeVoidAsync("loadImage", serviceReference, src, imageId);
      var completionSource = new TaskCompletionSource<Guid>();

      _imageLoadTasks[imageId] = completionSource;

      return await completionSource.Task;
    }

    [JSInvokable]
    public void OnImageLoaded(Guid imageId)
    {
      _imageLoadTasks[imageId].SetResult(imageId);
    }


    public async Task Clear(ElementReference canvas)
    {
      var module = await Module.Value;
      await module.InvokeVoidAsync("clear", canvas);
    }

    public async Task ClearUnmarshalled(Guid canvasId)
    {
      var module = await Module.Value;
      module.InvokeUnmarshalled<ClearCanvasStruct, string>("clearUnmarshalled", new ClearCanvasStruct {
        CanvasId = canvasId.ToString(),
      });
    }

    public async Task Draw(ElementReference canvas, IEnumerable<DrawOperationDetail> drawOperations)
    {
      var module = await Module.Value;
      await module.InvokeVoidAsync("draw", canvas, drawOperations);
    }

    public async Task DrawUnmarshalled(Guid canvasId, IEnumerable<DrawOperationDetail> drawOperations)
    {
      var module = await Module.Value;

      var drawOperationStructs = drawOperations.Select(o =>
        new DrawOperationDetailStruct {
          DrawOperation = (int)o.DrawOperation,
          X = o.X,
          Y = o.Y,
          Color = o.Color,
          Content = o.Content,
          Font = o.Font,
          Width = o.Width,
          Height = o.Height,
          StartAngle = o.StartAngle,
          EndAngle = o.EndAngle,
          Radius = o.Radius,
          Clockwise = o.Clockwise ? 1 : 0,
          X2 = o.X2,
          Y2 = o.Y2,
          Width2 = o.Width2,
          Height2 = o.Height2,
        });

      var drawStruct = new DrawOperationStruct {
        CanvasId = canvasId.ToString(),
      };

      module.InvokeUnmarshalled<DrawOperationStruct, DrawOperationDetailStruct[], string>("drawUnmarshalled", drawStruct, drawOperationStructs.ToArray());
    }
  }
}