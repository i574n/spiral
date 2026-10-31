program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TUS0 = record tag: LongInt; c1_0: THeap0; c1_1: THeap0; c1_2: THeap0; end;
  THeap1 = record l0: TUS0; end;
function score_0(v0: TUS0): LongInt; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: THeap0; a1: THeap0; a2: THeap0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function HeapCreate1(a0: TUS0): THeap1;
begin
  Result.l0 := a0;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: THeap0;
  v2: THeap0;
  v3: THeap0;
  v4: LongInt;
  v5: AnsiString;
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
  v20: Boolean;
  v19: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v0.c1_2;
          v4 := v1.l0;
          v5 := v1.l1;
          v6 := v2.l0;
          v7 := v2.l1;
          v8 := v3.l0;
          v9 := v3.l1;
          v10 := v4 = 7;
          if v10 then begin
              v11 := v5 = 'hi';
              v12 := v11;
          end else begin
              v12 := False;
          end;
          if v12 then begin
              v13 := v6 = 4;
              v14 := v13;
          end else begin
              v14 := False;
          end;
          if v14 then begin
              v15 := v7 = 'yo';
              v16 := v15;
          end else begin
              v16 := False;
          end;
          if v16 then begin
              v17 := v8 = 9;
              v18 := v17;
          end else begin
              v18 := False;
          end;
          if v18 then begin
              v19 := v9 = 'ok';
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
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: LongInt;
  v7: AnsiString;
  v8: THeap0;
  v9: Boolean;
  v12: TUS0;
  v13: THeap1;
  v14: TUS0;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  v6 := 9;
  v7 := 'ok';
  v8 := HeapCreate0(v6, v7);
  v9 := True;
  if v9 then begin
      v12 := US0_Held(v2, v5, v8);
  end else begin
      v12 := US0_None;
  end;
  v13 := HeapCreate1(v12);
  v14 := v13.l0;
  Result := score_0(v14);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
