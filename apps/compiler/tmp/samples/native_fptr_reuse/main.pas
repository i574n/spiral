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
  p: TSpiralFptr0;
  a: LongInt;
  b: LongInt;
begin
  p := @f;
  a := p(19);
  b := p(19);
  Result := a + b;
end;
begin
  Halt(SpiralMain);
end.
