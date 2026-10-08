program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: LongInt): Boolean; forward;
function method0(v0: LongInt): Boolean;
var
  v1: Boolean;
begin
  v1 := v0 < 10;
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := 0;
  v1 := 0;
  while method0(v0) do begin
      v3 := v1 + v0;
      v1 := v3;
      v4 := v0 + 1;
      v0 := v4;
  end;
  v5 := v1 - 45;
  Result := v5;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
