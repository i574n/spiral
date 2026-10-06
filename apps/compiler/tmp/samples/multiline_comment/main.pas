program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
  v3: Boolean;
begin
  v0 := 7;
  v1 := v0 * 2;
  v2 := v1 = 14;
  v3 := v2 <> True;
  if v3 then begin
      Result := 1;
  end else begin
      Result := 0;
  end;
end;
begin
  Halt(SpiralMain);
end.
