program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap1; end;
function score_0(v0: TUS0): LongInt; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: THeap1): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: THeap1;
  v2: THeap0;
  v3: LongInt;
  v4: LongInt;
  v5: AnsiString;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v10: Boolean;
  v9: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v1.l0;
          v3 := v1.l1;
          v4 := v2.l0;
          v5 := v2.l1;
          v6 := v4 = 7;
          if v6 then begin
              v7 := v5 = 'hi';
              v8 := v7;
          end else begin
              v8 := False;
          end;
          if v8 then begin
              v9 := v3 = 1;
              v10 := v9;
          end else begin
              v10 := False;
          end;
          if v10 then begin
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
  v5: Boolean;
  v8: TUS0;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := True;
  if v5 then begin
      v8 := US0_Held(v4);
  end else begin
      v8 := US0_None;
  end;
  Result := score_0(v8);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
