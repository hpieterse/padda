using System.Runtime.InteropServices;

namespace Handsaw.Padda.Engine.InteropStructs
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct DrawOperationStruct
  {
    [FieldOffset(0)]
    public string CanvasId;
  }
}
