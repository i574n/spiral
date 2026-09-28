program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralHeapRefs = class
  public
    q: LongInt;
    w: LongInt;
    constructor Create;
  end;

constructor TSpiralHeapRefs.Create;
begin
  inherited Create;
  q := 11;
  w := 13;
end;

function SpiralMain: LongInt;
var
  a, b: TSpiralHeapRefs;
begin
  a := TSpiralHeapRefs.Create;
  try
    b := a;
    a.q := 19;
    b.w := 23;
    Result := LongInt(a.q + b.w);
  finally
    a.Free;
  end;
end;

begin
  Halt(SpiralMain);
end.
