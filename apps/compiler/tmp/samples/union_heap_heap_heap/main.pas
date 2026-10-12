program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  THeap2 = record l0: THeap1; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap2; end;
function score_0(v0: TUS0): LongInt; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
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
  v5: LongInt;
  v6: LongInt;
  v7: AnsiString;
  v8: Boolean;
  v10: Boolean;
  v9: Boolean;
  v12: Boolean;
  v11: Boolean;
  v14: Boolean;
  v13: Boolean;
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
          v8 := v6 = 7;
          if v8 then begin
              v9 := v7 = 'hi';
              v10 := v9;
          end else begin
              v10 := False;
          end;
          if v10 then begin
              v11 := v5 = 1;
              v12 := v11;
          end else begin
              v12 := False;
          end;
          if v12 then begin
              v13 := v3 = 2;
              v14 := v13;
          end else begin
              v14 := False;
          end;
          if v14 then begin
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
  v4: THeap1;
  v5: LongInt;
  v6: THeap2;
  v7: Boolean;
  v10: TUS0;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := 2;
  v6 := HeapCreate2(v4, v5);
  v7 := True;
  if v7 then begin
      v10 := US0_Held(v6);
  end else begin
      v10 := US0_None;
  end;
  Result := score_0(v10);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
