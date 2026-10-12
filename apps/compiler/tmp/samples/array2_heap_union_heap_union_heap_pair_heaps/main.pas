program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap2; end;
  THeap3 = record l0: TUS0; end;
  TUS1 = record tag: LongInt; c1_0: THeap3; end;
  THeap4 = record l0: TUS1; end;
  TArray0 = array of THeap4;
function score_0(v0: TUS1): LongInt; forward;
function score_b_1(v0: TUS1): LongInt; forward;
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
function HeapCreate4(a0: TUS1): THeap4;
begin
  Result.l0 := a0;
end;
function score_0(v0: TUS1): LongInt;
var
  v1: THeap3;
  v2: TUS0;
  v3: THeap2;
  v4: THeap1;
  v5: LongInt;
  v6: THeap0;
  v7: THeap0;
  v8: LongInt;
  v9: AnsiString;
  v10: LongInt;
  v11: AnsiString;
  v12: Boolean;
  v14: Boolean;
  v13: Boolean;
  v16: Boolean;
  v15: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
begin
  case v0.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := v1.l0;
          case v2.tag of
              1: begin
                  v3 := v2.c1_0;
                  v4 := v3.l0;
                  v5 := v3.l1;
                  v6 := v4.l0;
                  v7 := v4.l1;
                  v8 := v6.l0;
                  v9 := v6.l1;
                  v10 := v7.l0;
                  v11 := v7.l1;
                  v12 := v8 = 7;
                  if v12 then begin
                      v13 := v9 = 'hi';
                      v14 := v13;
                  end else begin
                      v14 := False;
                  end;
                  if v14 then begin
                      v15 := v10 = 4;
                      v16 := v15;
                  end else begin
                      v16 := False;
                  end;
                  if v16 then begin
                      v17 := v11 = 'yo';
                      v18 := v17;
                  end else begin
                      v18 := False;
                  end;
                  if v18 then begin
                      v19 := v5 = 2;
                      v20 := v19;
                  end else begin
                      v20 := False;
                  end;
                  if v20 then begin
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
  end;
end;
function score_b_1(v0: TUS1): LongInt;
var
  v1: THeap3;
  v2: TUS0;
  v3: THeap2;
  v4: THeap1;
  v5: LongInt;
  v6: THeap0;
  v7: THeap0;
  v8: LongInt;
  v9: AnsiString;
  v10: LongInt;
  v11: AnsiString;
  v12: Boolean;
  v14: Boolean;
  v13: Boolean;
  v16: Boolean;
  v15: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
begin
  case v0.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := v1.l0;
          case v2.tag of
              1: begin
                  v3 := v2.c1_0;
                  v4 := v3.l0;
                  v5 := v3.l1;
                  v6 := v4.l0;
                  v7 := v4.l1;
                  v8 := v6.l0;
                  v9 := v6.l1;
                  v10 := v7.l0;
                  v11 := v7.l1;
                  v12 := v8 = 8;
                  if v12 then begin
                      v13 := v9 = 'ok';
                      v14 := v13;
                  end else begin
                      v14 := False;
                  end;
                  if v14 then begin
                      v15 := v10 = 5;
                      v16 := v15;
                  end else begin
                      v16 := False;
                  end;
                  if v16 then begin
                      v17 := v11 = 'no';
                      v18 := v17;
                  end else begin
                      v18 := False;
                  end;
                  if v18 then begin
                      v19 := v5 = 9;
                      v20 := v19;
                  end else begin
                      v20 := False;
                  end;
                  if v20 then begin
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
  v9: TUS0;
  v10: THeap3;
  v11: TUS1;
  v12: THeap4;
  v13: LongInt;
  v14: AnsiString;
  v15: THeap0;
  v16: LongInt;
  v17: AnsiString;
  v18: THeap0;
  v19: THeap1;
  v20: LongInt;
  v21: THeap2;
  v22: TUS0;
  v23: THeap3;
  v24: TUS1;
  v25: THeap4;
  v26: TArray0;
  tmp27: TArray0;
  v27: THeap4;
  v28: THeap4;
  v29: TUS1;
  v30: TUS1;
  v31: LongInt;
  v32: LongInt;
  v33: Boolean;
  v35: Boolean;
  v34: Boolean;
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
  v9 := US0_Held(v8);
  v10 := HeapCreate3(v9);
  v11 := US1_Box(v10);
  v12 := HeapCreate4(v11);
  v13 := 8;
  v14 := 'ok';
  v15 := HeapCreate0(v13, v14);
  v16 := 5;
  v17 := 'no';
  v18 := HeapCreate0(v16, v17);
  v19 := HeapCreate1(v15, v18);
  v20 := 9;
  v21 := HeapCreate2(v19, v20);
  v22 := US0_Held(v21);
  v23 := HeapCreate3(v22);
  v24 := US1_Box(v23);
  v25 := HeapCreate4(v24);
  tmp27 := nil;
  SetLength(tmp27, 2);
  v26 := tmp27;
  v26[0] := v12;
  v26[1] := v25;
  v27 := v26[0];
  v28 := v26[1];
  v29 := v27.l0;
  v30 := v28.l0;
  v31 := score_0(v29);
  v32 := score_b_1(v30);
  v33 := v31 = 0;
  if v33 then begin
      v34 := v32 = 0;
      v35 := v34;
  end else begin
      v35 := False;
  end;
  if v35 then begin
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
