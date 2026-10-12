program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: Single; v1: Single): Single; forward;
function method0(v0: Single; v1: Single): Single;
var
  v2: Single;
  v3: Single;
begin
  v2 := v0 * v1;
  v3 := v2 + 0.5;
  Result := v3;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Single;
  v2: Single;
  v3: Boolean;
begin
  v0 := 1.5;
  v1 := 2.0;
  v2 := method0(v0, v1);
  v3 := v2 >= 3.5;
  if v3 then begin
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
