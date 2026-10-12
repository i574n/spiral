program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 2);
  v0 := tmp1;
  v1 := 'ab';
  v0[0] := v1;
  v2 := 'cde';
  v0[1] := v2;
  v3 := v0[0];
  v4 := v0[1];
  v5 := LongInt(Length(v3));
  v6 := LongInt(Length(v4));
  v7 := v5 + v6;
  v8 := v7 - 5;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
