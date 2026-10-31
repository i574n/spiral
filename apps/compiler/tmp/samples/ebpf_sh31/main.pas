program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: LongInt;
  v2: LongInt;
  v3: LongWord;
  v4: LongWord;
  v5: LongWord;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v10: Boolean;
  v9: Boolean;
begin
  v0 := 1;
  v1 := 0;
  v2 := 31;
  v3 := v0 shl v2;
  v4 := v3 shr v2;
  v5 := v0 shl v1;
  v6 := v3 = 2147483648;
  if v6 then begin
      v7 := v4 = 1;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
      v9 := v5 = 1;
      v10 := v9;
  end else begin
      v10 := False;
  end;
  if v10 then begin
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
