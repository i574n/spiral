program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS1 = record tag: LongInt; c0_0: LongInt; c0_1: LongInt; end;
  TUS2 = record tag: LongInt; c0_0: LongInt; end;
  TUS0 = record tag: LongInt; c0_0: TUS1; c1_0: TUS2; end;
function US1_Living(a0: LongInt; a1: LongInt): TUS1;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function US2_Fallen(a0: LongInt): TUS2;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Survived(a0: TUS1): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Slain(a0: TUS2): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v6: TUS0;
  v2: TUS1;
  v4: TUS2;
  v13: TUS2;
  v7: TUS1;
  v8: LongInt;
  v9: LongInt;
  v10: Boolean;
begin
  v0 := 60;
  v1 := v0 > 0;
  if v1 then begin
      v2 := US1_Living(v0, 100);
      v6 := US0_Survived(v2);
  end else begin
      v4 := US2_Fallen(100);
      v6 := US0_Slain(v4);
  end;
  case v6.tag of
      1: begin
          v13 := v6.c1_0;
          Result := 2;
      end;
      0: begin
          v7 := v6.c0_0;
          case v7.tag of
              0: begin
                  v8 := v7.c0_0;
                  v9 := v7.c0_1;
                  v10 := v8 = 60;
                  if v10 then begin
                      Result := 0;
                  end else begin
                      Result := 1;
                  end;
              end;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
