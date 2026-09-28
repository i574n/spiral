program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralStackLayout = record
    q: LongInt;
    w: LongInt;
  end;

function SpiralMain: LongInt;
var
  a, b, c: TSpiralStackLayout;
begin
  a.q := 5;
  a.w := 6;
  a.q := 7;
  b := a;
  a.w := 8;
  c := a;
  Result := LongInt(b.q + c.w);
end;

begin
  Halt(SpiralMain);
end.
