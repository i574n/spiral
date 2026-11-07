program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: Double; c1_0: LongInt; end;
function twice_1(v0: Double): LongInt; forward;
function score_0(v0: TUS0): LongInt; forward;
function US0_Real(a0: Double): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Whole(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function twice_1(v0: Double): LongInt;
var
  v1: Double;
  v2: LongInt;
begin
  v1 := v0 * 2.0;
  v2 := LongInt(Trunc(v1));
  Result := v2;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: Double;
  v3: LongInt;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          Result := twice_1(v1);
      end;
      1: begin
          v3 := v0.c1_0;
          Result := v3;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: Double;
  v4: TUS0;
  v7: TUS0;
  v8: LongInt;
  v9: Boolean;
  v12: Boolean;
  v10: LongInt;
  v11: Boolean;
begin
  v0 := True;
  v1 := 1.5;
  if v0 then begin
      v4 := US0_Real(v1);
  end else begin
      v4 := US0_Whole(1);
  end;
  if v0 then begin
      v7 := US0_Whole(5);
  end else begin
      v7 := US0_Real(v1);
  end;
  v8 := score_0(v4);
  v9 := v8 = 3;
  if v9 then begin
      v10 := score_0(v7);
      v11 := v10 = 5;
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
