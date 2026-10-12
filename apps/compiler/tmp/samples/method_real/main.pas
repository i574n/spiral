program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: LongInt): Double; forward;
function method0(v0: LongInt): Double;
var
  v1: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := 0.0;
  end else begin
      Result := 1.5;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Double;
  v2: Boolean;
begin
  v0 := 7;
  v1 := method0(v0);
  v2 := v1 = 1.5;
  if v2 then begin
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
