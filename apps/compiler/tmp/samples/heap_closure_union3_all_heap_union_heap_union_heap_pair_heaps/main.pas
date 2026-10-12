program SpiralGenerated;
{$mode delphi}{$H+}
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
  THeap4 = record l0: TUS1; end;
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
function HeapCreate4(a0: TUS1): THeap4;
begin
  Result.l0 := a0;
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
  v2: Boolean;
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
          v2 := v1 = 0;
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
  v20: TUS1;
  v21: THeap4;
  v22: TUS1;
  v23: THeap4;
  v24: TUS1;
  v25: THeap4;
  v26: TUS1;
  v27: TUS1;
  v28: TUS1;
  v29: LongInt;
  v30: LongInt;
  v31: LongInt;
  v32: Boolean;
  v34: Boolean;
  v33: Boolean;
  v36: Boolean;
  v35: Boolean;
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
  v20 := v19.Invoke(1);
  v21 := HeapCreate4(v20);
  v22 := v19.Invoke(2);
  v23 := HeapCreate4(v22);
  v24 := v19.Invoke(0);
  v25 := HeapCreate4(v24);
  v26 := v21.l0;
  v27 := v23.l0;
  v28 := v25.l0;
  v29 := score_0(v26);
  v30 := score_0(v27);
  v31 := score_0(v28);
  v32 := v29 = 0;
  if v32 then begin
      v33 := v30 = 1;
      v34 := v33;
  end else begin
      v34 := False;
  end;
  if v34 then begin
      v35 := v31 = 1;
      v36 := v35;
  end else begin
      v36 := False;
  end;
  if v36 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
