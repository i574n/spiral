program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
  TUS1 = record tag: LongInt; c0_0: LongInt; c0_1: Boolean; end;
  TUS2 = record tag: LongInt; c0_0: LongInt; end;
  TUS3 = record tag: LongInt; c0_0: Boolean; c0_1: LongInt; end;
  TUS4 = record tag: LongInt; c0_0: LongInt; end;
  TUS5 = record tag: LongInt; c0_0: LongInt; c0_1: Boolean; end;
  TUS6 = record tag: LongInt; c0_0: Boolean; end;
function decide_a_0(v0: TUS0): TUS1; forward;
function decide_b_1(v0: TUS2): TUS3; forward;
function decide_c_2(v0: TUS4): TUS5; forward;
function finalize_c_3(v0: TUS5): TUS6; forward;
function US0_RawA(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US1_DecidedA(a0: LongInt; a1: Boolean): TUS1;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function decide_a_0(v0: TUS0): TUS1;
var
  v1: LongInt;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          Result := US1_DecidedA(v1, True);
      end;
  end;
end;
function US2_RawB(a0: LongInt): TUS2;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US3_DecidedB(a0: Boolean; a1: LongInt): TUS3;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function decide_b_1(v0: TUS2): TUS3;
var
  v1: LongInt;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          Result := US3_DecidedB(True, v1);
      end;
  end;
end;
function US4_RawC(a0: LongInt): TUS4;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US5_DecidedC(a0: LongInt; a1: Boolean): TUS5;
begin
  Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function decide_c_2(v0: TUS4): TUS5;
var
  v1: LongInt;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          Result := US5_DecidedC(v1, True);
      end;
  end;
end;
function US6_FinalC(a0: Boolean): TUS6;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function finalize_c_3(v0: TUS5): TUS6;
var
  v1: LongInt;
  v2: Boolean;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          v2 := v0.c0_1;
          Result := US6_FinalC(v2);
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: TUS1;
  v3: LongInt;
  v4: TUS2;
  v5: TUS3;
  v6: LongInt;
  v7: TUS4;
  v8: TUS5;
  v9: TUS6;
  v12: Boolean;
  v10: LongInt;
  v11: Boolean;
  v15: Boolean;
  v13: Boolean;
  v14: LongInt;
  v17: Boolean;
  v16: Boolean;
  v18: Boolean;
  v19: Boolean;
begin
  v0 := 7;
  v1 := US0_RawA(v0);
  v2 := decide_a_0(v1);
  v3 := 9;
  v4 := US2_RawB(v3);
  v5 := decide_b_1(v4);
  v6 := 11;
  v7 := US4_RawC(v6);
  v8 := decide_c_2(v7);
  v9 := finalize_c_3(v8);
  case v2.tag of
      0: begin
          v10 := v2.c0_0;
          v11 := v2.c0_1;
          v12 := v11;
      end;
  end;
  case v5.tag of
      0: begin
          v13 := v5.c0_0;
          v14 := v5.c0_1;
          v15 := v13;
      end;
  end;
  case v9.tag of
      0: begin
          v16 := v9.c0_0;
          v17 := v16;
      end;
  end;
  v18 := v12 and v15;
  v19 := v18 and v17;
  if v19 then begin
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
