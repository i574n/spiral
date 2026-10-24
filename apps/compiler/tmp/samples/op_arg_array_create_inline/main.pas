program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongWord;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TArray0;
  tmp3: TArray0;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 3;
  v1 := v0 * 4;
  tmp3 := nil;
  SetLength(tmp3, v1);
  v2 := tmp3;
  v3 := LongInt(Length(v2));
  v4 := v3 - 12;
  Result := v4;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
