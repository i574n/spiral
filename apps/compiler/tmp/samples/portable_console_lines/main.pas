program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v16: AnsiString;
  v17: LongInt;
  v32: AnsiString;
  v44: AnsiString;
  v57: AnsiString;
  v58: Int64;
begin
  v16 := 'hello';
  Writeln(v16);
  v17 := 42;
  Writeln(v17);
  v32 := 'a';
  Write(v32);
  v44 := 'b';
  Write(v44);
  v57 := '';
  Writeln(v57);
  v58 := (-7);
  Writeln(v58);
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
