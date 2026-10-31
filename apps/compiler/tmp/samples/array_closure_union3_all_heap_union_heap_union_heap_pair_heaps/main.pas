program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap2; end;
  THeap3 = record l0: TUS0; end;
  TUS1 = record tag: LongInt; c1_0: THeap3; c2_0: LongInt; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS1; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: TUS1; v1: LongInt; function Invoke(v2: LongInt): TUS1; override; end;
  TArray0 = array of TUS1;
function ClosureCreate0(v0: TUS1; v1: LongInt): TFun0; forward;
function score_0(v0: TUS1): LongInt; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: THeap0): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate2(a0: THeap1; a1: LongInt): THeap2;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: THeap2): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function HeapCreate3(a0: TUS0): THeap3;
begin
  Result.l0 := a0;
end;
function US1_Absent: TUS1;
begin
  Result.tag := 0; 
end;
function US1_Box(a0: THeap3): TUS1;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US1_Mark(a0: LongInt): TUS1;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function Tf_c0.Invoke(v2: LongInt): TUS1;
var
  v3: Boolean;
  v5: Boolean;
begin
  v3 := v2 = 0;
  if v3 then begin
      Result := US1_Absent;
  end else begin
      v5 := v2 = 1;
      if v5 then begin
          Result := v0;
      end else begin
          Result := US1_Mark(v1);
      end;
  end;
end;
function ClosureCreate0(v0: TUS1; v1: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function score_0(v0: TUS1): LongInt;
var
  v3: THeap3;
  v4: TUS0;
  v5: THeap2;
  v6: THeap1;
  v7: LongInt;
  v8: THeap0;
  v9: THeap0;
  v10: LongInt;
  v11: AnsiString;
  v12: LongInt;
  v13: AnsiString;
  v14: Boolean;
  v16: Boolean;
  v15: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
  v22: Boolean;
  v21: Boolean;
  v1: LongInt;
begin
  case v0.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v3 := v0.c1_0;
          v4 := v3.l0;
          case v4.tag of
              1: begin
                  v5 := v4.c1_0;
                  v6 := v5.l0;
                  v7 := v5.l1;
                  v8 := v6.l0;
                  v9 := v6.l1;
                  v10 := v8.l0;
                  v11 := v8.l1;
                  v12 := v9.l0;
                  v13 := v9.l1;
                  v14 := v10 = 7;
                  if v14 then begin
                      v15 := v11 = 'hi';
                      v16 := v15;
                  end else begin
                      v16 := False;
                  end;
                  if v16 then begin
                      v17 := v12 = 4;
                      v18 := v17;
                  end else begin
                      v18 := False;
                  end;
                  if v18 then begin
                      v19 := v13 = 'yo';
                      v20 := v19;
                  end else begin
                      v20 := False;
                  end;
                  if v20 then begin
                      v21 := v7 = 2;
                      v22 := v21;
                  end else begin
                      v22 := False;
                  end;
                  if v22 then begin
                      Result := 0;
                  end else begin
                      Result := 1;
                  end;
              end;
              0: begin
                  Result := 1;
              end;
          end;
      end;
      2: begin
          v1 := v0.c2_0;
          Result := 1;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: THeap1;
  v7: LongInt;
  v8: THeap2;
  v9: Boolean;
  v12: TUS0;
  v13: THeap3;
  v14: Boolean;
  v17: TUS1;
  v18: LongInt;
  v19: TFun0;
  v20: TArray0;
  tmp17: TArray0;
  v21: TUS1;
  v22: TUS1;
  v23: TUS1;
  v24: TUS1;
  v25: LongInt;
  v26: TUS1;
  v27: LongInt;
  v28: TUS1;
  v29: LongInt;
  v30: Boolean;
  v32: Boolean;
  v31: Boolean;
  v34: Boolean;
  v33: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := HeapCreate1(v2, v5);
  v7 := 2;
  v8 := HeapCreate2(v6, v7);
  v9 := True;
  if v9 then begin
      v12 := US0_Held(v8);
  end else begin
      v12 := US0_None;
  end;
  v13 := HeapCreate3(v12);
  v14 := True;
  if v14 then begin
      v17 := US1_Box(v13);
  end else begin
      v17 := US1_Mark(1);
  end;
  v18 := 3;
  v19 := ClosureCreate0(v17, v18);
  tmp17 := nil;
  SetLength(tmp17, 3);
  v20 := tmp17;
  v21 := v19.Invoke(1);
  v20[0] := v21;
  v22 := v19.Invoke(2);
  v20[1] := v22;
  v23 := v19.Invoke(0);
  v20[2] := v23;
  v24 := v20[0];
  v25 := score_0(v24);
  v26 := v20[1];
  v27 := score_0(v26);
  v28 := v20[2];
  v29 := score_0(v28);
  v30 := v25 = 0;
  if v30 then begin
      v31 := v27 = 1;
      v32 := v31;
  end else begin
      v32 := False;
  end;
  if v32 then begin
      v33 := v29 = 1;
      v34 := v33;
  end else begin
      v34 := False;
  end;
  if v34 then begin
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
