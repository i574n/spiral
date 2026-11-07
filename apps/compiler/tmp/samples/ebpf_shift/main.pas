program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongWord;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongWord;
  v8: LongWord;
  v9: Boolean;
  v10: Boolean;
  v11: Boolean;
  v12: Boolean;
begin
  v0 := (-8);
  v1 := 3;
  v2 := 1;
  v3 := 4294967295;
  v4 := 4;
  v5 := SarLongint(v0, v2);
  v6 := v1 shl v2;
  v7 := v3 shr v4;
  v8 := v3 shl v2;
  v9 := v5 = (-4);
  if v9 then begin
      v10 := v6 = 6;
      if v10 then begin
          v11 := v7 = 268435455;
          if v11 then begin
              v12 := v8 = 4294967294;
              if v12 then begin
                  Result := 0;
              end else begin
                  Result := 4;
              end;
          end else begin
              Result := 3;
          end;
      end else begin
          Result := 2;
      end;
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
