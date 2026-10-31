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
  v15: LongInt;
  v16: AnsiString;
  v17: THeap0;
  v18: LongInt;
  v19: AnsiString;
  v20: THeap0;
  v21: THeap1;
  v22: LongInt;
  v23: THeap2;
  v24: Boolean;
  v27: TUS0;
  v28: THeap3;
  v29: THeap3;
  v30: TUS0;
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
  v15 := 7;
  v16 := 'hi';
  v17 := HeapCreate0(v15, v16);
  v18 := 4;
  v19 := 'yo';
  v20 := HeapCreate0(v18, v19);
  v21 := HeapCreate1(v17, v20);
  v22 := 2;
  v23 := HeapCreate2(v21, v22);
  v24 := True;
  if v24 then begin
      v27 := US0_Held(v23);
  end else begin
      v27 := US0_None;
  end;
  v28 := HeapCreate3(v27);
  v14.l0 := v28;
  v29 := v14.l0;
  v30 := v29.l0;
  Result := score_0(v30);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
