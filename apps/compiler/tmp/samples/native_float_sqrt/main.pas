program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Double;
  v2: Single;
  v3: Double;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
begin
  v0 := 144.0;
  v1 := 81.0;
  v2 := Sqrt(v0);
  v3 := Sqrt(v1);
  v4 := v2 = 12.0;
  if v4 then begin
      v5 := v3 = 9.0;
      v6 := v5;
  end else begin
      v6 := False;
  end;
  if v6 then begin
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
