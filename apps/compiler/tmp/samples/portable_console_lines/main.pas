program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: Int64;
begin
  v0 := 'hello';
  Writeln(v0);
  v1 := 42;
  Writeln(v1);
  v2 := 'a';
  Write(v2);
  v3 := 'b';
  Write(v3);
  v4 := '';
  Writeln(v4);
  v5 := (-7);
  Writeln(v5);
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
