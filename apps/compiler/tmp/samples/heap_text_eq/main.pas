program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: AnsiString; l1: AnsiString; end;
function HeapCreate0(a0: AnsiString; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: THeap0;
  v2: AnsiString;
  v3: AnsiString;
  v4: Boolean;
begin
  v0 := 'hi';
  v1 := HeapCreate0(v0, v0);
  v2 := v1.l0;
  v3 := v1.l1;
  v4 := v2 = v3;
  if v4 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
