program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c0_1: LongInt; c0_2: LongInt; end;
function walk_0(v0: LongInt): LongInt; forward;
function US0_Step(a0: LongInt; a1: LongInt; a2: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1; Result.c0_2 := a2;
end;
function walk_0(v0: LongInt): LongInt;
var
  v1: Boolean;
  v6: TUS0;
  v2: LongInt;
  v3: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
begin
  v1 := v0 > 2;
  if v1 then begin
      v2 := v0 + 1;
      v3 := v0 + 2;
      v6 := US0_Step(v0, v2, v3);
  end else begin
      v6 := US0_Step(0, 1, 2);
  end;
  case v6.tag of
      0: begin
          v7 := v6.c0_0;
          v8 := v6.c0_1;
          v9 := v6.c0_2;
          v10 := v8 * v9;
          v11 := v7 + v10;
          Result := v11;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v0 := 5;
  v1 := walk_0(v0);
  v2 := v0 - 4;
  v3 := walk_0(v2);
  v4 := v1 + v3;
  Result := v4;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
