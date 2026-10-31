program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c2_0: LongInt; end;
function pick_0(v0: LongInt): TUS0; forward;
function measure_1(v0: TUS0; v1: LongInt): LongInt; forward;
function measure_tri_2(v0: TUS0; v1: LongInt): LongInt; forward;
function US0_Circle(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Square(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Tri(a0: LongInt): TUS0;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function US0_Dot: TUS0;
begin
  Result.tag := 3; 
end;
function pick_0(v0: LongInt): TUS0;
var
  v1: Boolean;
  v3: Boolean;
  v5: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := US0_Circle(5);
  end else begin
      v3 := v0 = 1;
      if v3 then begin
          Result := US0_Square(4);
      end else begin
          v5 := v0 = 2;
          if v5 then begin
              Result := US0_Tri(7);
          end else begin
              Result := US0_Dot;
          end;
      end;
  end;
end;
function measure_1(v0: TUS0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: Boolean;
  v6: LongInt;
  v7: LongInt;
  v9: LongInt;
  v10: LongInt;
begin
  case v0.tag of
      0: begin
          v2 := v0.c0_0;
          v3 := v2 * 3;
          Result := v3;
      end;
      else begin
          v4 := v1 * v1;
          v5 := v4 > 3;
          case v0.tag of
              3: begin
                  Result := v4;
              end;
              1: begin
                  v6 := v0.c1_0;
                  if v5 then begin
                      v7 := v6 * v6;
                      Result := v7;
                  end else begin
                      Result := v6;
                  end;
              end;
              2: begin
                  v9 := v0.c2_0;
                  if v5 then begin
                      v10 := v9 * 2;
                      Result := v10;
                  end else begin
                      Result := v9;
                  end;
              end;
          end;
      end;
  end;
end;
function measure_tri_2(v0: TUS0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  case v0.tag of
      0: begin
          v2 := v0.c0_0;
          Result := v2;
      end;
      3: begin
          Result := 0;
      end;
      1: begin
          v3 := v0.c1_0;
          Result := v3;
      end;
      else begin
          v4 := v1 + 2;
          case v0.tag of
              2: begin
                  v5 := v0.c2_0;
                  v6 := v5 * v4;
                  Result := v6;
              end;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: LongInt;
  v3: LongInt;
  v4: TUS0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: TUS0;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: TUS0;
  v13: LongInt;
  v14: LongInt;
  v15: TUS0;
  v16: LongInt;
  v17: LongInt;
  v18: TUS0;
  v19: LongInt;
  v20: LongInt;
begin
  v0 := 0;
  v1 := pick_0(v0);
  v2 := measure_1(v1, v0);
  v3 := v0 + 1;
  v4 := pick_0(v3);
  v5 := measure_1(v4, v3);
  v6 := v2 + v5;
  v7 := v0 + 2;
  v8 := pick_0(v7);
  v9 := measure_1(v8, v7);
  v10 := v6 + v9;
  v11 := v0 + 3;
  v12 := pick_0(v11);
  v13 := measure_1(v12, v11);
  v14 := v10 + v13;
  v15 := pick_0(v7);
  v16 := measure_tri_2(v15, v0);
  v17 := v14 + v16;
  v18 := pick_0(v0);
  v19 := measure_tri_2(v18, v0);
  v20 := v17 + v19;
  Result := v20;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
