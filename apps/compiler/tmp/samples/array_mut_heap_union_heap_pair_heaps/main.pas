program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut4 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap2; end;
  THeap3 = record l0: TUS0; end;
  TMut4 = class l0: THeap3; end;
  TArray0 = array of TMut4;
function score_0(v0: TUS0): LongInt; forward;
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
function MutCreate4(a0: THeap3): TMut4;
begin
  Result := TMut4.Create; Result.l0 := a0;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: THeap2;
  v2: THeap1;
  v3: LongInt;
  v4: THeap0;
  v5: THeap0;
  v6: LongInt;
  v7: AnsiString;
  v8: LongInt;
  v9: AnsiString;
  v10: Boolean;
  v12: Boolean;
  v11: Boolean;
  v14: Boolean;
  v13: Boolean;
  v16: Boolean;
  v15: Boolean;
  v18: Boolean;
  v17: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v1.l0;
          v3 := v1.l1;
          v4 := v2.l0;
          v5 := v2.l1;
          v6 := v4.l0;
          v7 := v4.l1;
          v8 := v5.l0;
          v9 := v5.l1;
          v10 := v6 = 7;
          if v10 then begin
              v11 := v7 = 'hi';
              v12 := v11;
          end else begin
              v12 := False;
          end;
          if v12 then begin
              v13 := v8 = 4;
              v14 := v13;
          end else begin
              v14 := False;
          end;
          if v14 then begin
              v15 := v9 = 'yo';
              v16 := v15;
          end else begin
              v16 := False;
          end;
          if v16 then begin
              v17 := v3 = 2;
              v18 := v17;
          end else begin
              v18 := False;
          end;
          if v18 then begin
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
  v14: TMut4;
  v15: TArray0;
  tmp14: TArray0;
  v16: LongInt;
  v17: AnsiString;
  v18: THeap0;
  v19: LongInt;
  v20: AnsiString;
  v21: THeap0;
  v22: THeap1;
  v23: LongInt;
  v24: THeap2;
  v25: Boolean;
  v28: TUS0;
  v29: THeap3;
  v30: TMut4;
  v31: THeap3;
  v32: TUS0;
begin
  v0 := 1;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 2;
  v4 := 'zz';
  v5 := HeapCreate0(v3, v4);
  v6 := HeapCreate1(v2, v5);
  v7 := 3;
  v8 := HeapCreate2(v6, v7);
  v9 := True;
  if v9 then begin
      v12 := US0_Held(v8);
  end else begin
      v12 := US0_None;
  end;
  v13 := HeapCreate3(v12);
  v14 := MutCreate4(v13);
  tmp14 := nil;
  SetLength(tmp14, 1);
  v15 := tmp14;
  v15[0] := v14;
  v16 := 7;
  v17 := 'hi';
  v18 := HeapCreate0(v16, v17);
  v19 := 4;
  v20 := 'yo';
  v21 := HeapCreate0(v19, v20);
  v22 := HeapCreate1(v18, v21);
  v23 := 2;
  v24 := HeapCreate2(v22, v23);
  v25 := True;
  if v25 then begin
      v28 := US0_Held(v24);
  end else begin
      v28 := US0_None;
  end;
  v29 := HeapCreate3(v28);
  v30 := v15[0];
  v30.l0 := v29;
  v31 := v30.l0;
  v32 := v31.l0;
  Result := score_0(v32);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
