using System.Runtime.InteropServices;

namespace Handsaw.Padda.Engine.InteropStructs
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct SetSizeStruct
  {
    [FieldOffset(8)]
    public string CanvasId;

    [FieldOffset(0)]
    public float Width;

    [FieldOffset(4)]
    public float Height;
  }
}
