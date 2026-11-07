program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS1 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; end;
  TUS0 = record tag: LongInt; c0_0: TUS1; c1_0: LongInt; end;
function score_inner_1(v0: TUS1): LongInt; forward;
function score_0(v0: TUS0): LongInt; forward;
function US1_A(a0: LongInt): TUS1;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US1_B(a0: LongInt): TUS1;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Wrap(a0: TUS1): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Other(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function score_inner_1(v0: TUS1): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          Result := v1;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := -v2;
          Result := v3;
      end;
  end;
end;
function score_0(v0: TUS0): LongInt;
var
  v3: LongInt;
  v1: TUS1;
begin
  case v0.tag of
      1: begin
          v3 := v0.c1_0;
          Result := v3;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := score_inner_1(v1);
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v4: TUS0;
  v1: TUS1;
  v8: TUS0;
  v6: TUS1;
  v9: LongInt;
  v10: Boolean;
  v13: Boolean;
  v11: LongInt;
  v12: Boolean;
begin
  v0 := True;
  if v0 then begin
      v1 := US1_A(7);
      v4 := US0_Wrap(v1);
  end else begin
      v4 := US0_Other(1);
  end;
  if v0 then begin
      v8 := US0_Other(4);
  end else begin
      v6 := US1_B(2);
      v8 := US0_Wrap(v6);
  end;
  v9 := score_0(v4);
  v10 := v9 = 7;
  if v10 then begin
      v11 := score_0(v8);
      v12 := v11 = 4;
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
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
