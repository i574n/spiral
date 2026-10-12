program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := 'qwe';
  v1 := LongInt(Length(v0));
  v2 := v1 + v1;
  v3 := v2 - 6;
  Result := v3;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
