program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Single;
  v2: Single;
  v3: Single;
  v4: Single;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 1.5;
  v1 := (-2.0);
  v2 := (-0.5);
  v3 := v0 / v1;
  v4 := v2 / v1;
  v5 := v3 = (-0.75);
  if v5 then begin
      v6 := v4 = 0.25;
      v7 := v6;
  end else begin
      v7 := False;
  end;
  if v7 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
