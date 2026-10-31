program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: Boolean; l1: AnsiString; end;
function HeapCreate0(a0: Boolean; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: AnsiString;
  v2: THeap0;
  v3: Boolean;
  v4: AnsiString;
  v6: Boolean;
  v5: Boolean;
begin
  v0 := True;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := v2.l0;
  v4 := v2.l1;
  if v3 then begin
      v5 := v4 = 'hi';
      v6 := v5;
  end else begin
      v6 := False;
  end;
  if v6 then begin
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
