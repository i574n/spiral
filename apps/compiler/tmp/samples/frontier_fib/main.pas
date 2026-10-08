program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: LongInt): LongInt; forward;
function method0(v0: LongInt): LongInt;
var
  v1: Boolean;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v1 := v0 <= 1;
  if v1 then begin
      Result := v0;
  end else begin
      v2 := v0 - 1;
      v3 := method0(v2);
      v4 := v0 - 2;
      v5 := method0(v4);
      v6 := v3 + v5;
      Result := v6;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
begin
  v0 := 10;
  v1 := method0(v0);
  v2 := v1 - 55;
  Result := v2;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
