program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: THeap0; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap2; end;
  TArray0 = array of TUS0;
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
  v9: TArray0;
  tmp10: TArray0;
  v10: Boolean;
  v13: TUS0;
  v14: TUS0;
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
  tmp10 := nil;
  SetLength(tmp10, 1);
  v9 := tmp10;
  v10 := True;
  if v10 then begin
      v13 := US0_Held(v8);
  end else begin
      v13 := US0_None;
  end;
  v9[0] := v13;
  v14 := v9[0];
  Result := score_0(v14);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
