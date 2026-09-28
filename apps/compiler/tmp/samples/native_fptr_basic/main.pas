program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralFptr0 = function(value: LongInt): LongInt;
function f(value: LongInt): LongInt;
begin
  Result := value + 2;
end;
function SpiralMain: LongInt;
var
  x: LongInt;
  p: TSpiralFptr0;
begin
  x := 40;
  p := @f;
  Result := p(x);
end;
begin
  Halt(SpiralMain);
end.
