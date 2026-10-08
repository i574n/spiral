program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: AnsiString): LongInt; forward;
function method0(v0: AnsiString): LongInt;
var
  v1: LongInt;
begin
  v1 := LongInt(Length(v0));
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 'qwe';
  v1 := method0(v0);
  v2 := method0(v0);
  v3 := v1 + v2;
  v4 := v3 - 6;
  Result := v4;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
