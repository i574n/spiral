program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TUS0 = record tag: LongInt; c1_0: THeap0; c1_1: THeap0; end;
  TArray0 = array of TUS0;
function score_0(v0: TUS0): LongInt; forward;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: THeap0; a1: THeap0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function score_0(v0: TUS0): LongInt;
var
  v1: THeap0;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: LongInt;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
  v11: Boolean;
  v10: Boolean;
  v13: Boolean;
  v12: Boolean;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v1.l0;
          v4 := v1.l1;
          v5 := v2.l0;
          v6 := v2.l1;
          v7 := v3 = 7;
          if v7 then begin
              v8 := v4 = 'hi';
              v9 := v8;
          end else begin
              v9 := False;
          end;
          if v9 then begin
              v10 := v5 = 4;
              v11 := v10;
          end else begin
              v11 := False;
          end;
          if v11 then begin
              v12 := v6 = 'yo';
              v13 := v12;
          end else begin
              v13 := False;
          end;
          if v13 then begin
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
  v6: TArray0;
  tmp7: TArray0;
  v7: Boolean;
  v10: TUS0;
  v11: TUS0;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := 4;
  v4 := 'yo';
  v5 := HeapCreate0(v3, v4);
  tmp7 := nil;
  SetLength(tmp7, 1);
  v6 := tmp7;
  v7 := True;
  if v7 then begin
      v10 := US0_Held(v2, v5);
  end else begin
      v10 := US0_None;
  end;
  v6[0] := v10;
  v11 := v6[0];
  Result := score_0(v11);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
