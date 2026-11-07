program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongWord;
  v1: LongWord;
  v2: LongWord;
  v3: LongWord;
  v4: LongWord;
  v5: LongWord;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v10: Boolean;
  v9: Boolean;
  v12: Boolean;
  v11: Boolean;
begin
  v0 := 4294967295;
  v1 := 15;
  v2 := v0 and v1;
  v3 := v0 or v1;
  v4 := v0 xor v1;
  v5 := not v1;
  v6 := v2 = 15;
  if v6 then begin
      v7 := v3 = v0;
      v8 := v7;
  end else begin
      v8 := False;
  end;
  if v8 then begin
      v9 := v4 = v5;
      v10 := v9;
  end else begin
      v10 := False;
  end;
  if v10 then begin
      v11 := v5 = 4294967280;
      v12 := v11;
  end else begin
      v12 := False;
  end;
  if v12 then begin
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
