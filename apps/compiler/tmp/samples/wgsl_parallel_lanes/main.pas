program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: LongWord;
  v2: LongWord;
  v3: LongWord;
  v4: LongInt;
begin
  v0 := 0;
  v1 := v0 * v0;
  v2 := v1 + 7;
  v3 := v2 mod 251;
  v4 := LongInt(v3);
  Result := v4;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
