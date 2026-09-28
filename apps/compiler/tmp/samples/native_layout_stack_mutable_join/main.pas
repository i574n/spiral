program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralStackLayout = record
    q: LongInt;
    w: LongInt;
  end;

function SpiralMain: LongInt;
var
  a, b: TSpiralStackLayout;
begin
  a.q := 5;
  a.w := 6;
  if a.q < 10 then begin
    a.q := 7;
  end else begin
    a.q := 9;
  end;
  b := a;
  a.w := 8;
  Result := LongInt(b.q + a.w);
end;

begin
  Halt(SpiralMain);
end.
