using System.Runtime.InteropServices;

namespace Handsaw.Padda.Engine.InteropStructs
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct DrawOperationDetailStruct
  {
    [FieldOffset(0)]
    public int DrawOperation;

    [FieldOffset(4)]
    public float X;

    [FieldOffset(8)]
    public float Y;

    [FieldOffset(12)] // 12, 12
    public string Color;

    [FieldOffset(24)] // 24, 128
    public string Content;

    [FieldOffset(156)] // 156, 128
    public string Font;

    [FieldOffset(280)] // 280, 4
    public float Width;

    [FieldOffset(284)] // 284, 4
    public float Height;

    [FieldOffset(288)] // 288, 4
    public float Radius;

    [FieldOffset(296)] // 296, 4
    public float StartAngle;

    [FieldOffset(300)] // 300, 4
    public float EndAngle;

    [FieldOffset(304)] // 304, 4
    public int Clockwise;

    [FieldOffset(308)] // 308, 4
    public float X2;

    [FieldOffset(312)] // 312, 4
    public float Y2;

    [FieldOffset(316)] // 316, 4
    public float Width2;

    [FieldOffset(320)] // 320, 4
    public float Height2;
  }
}
