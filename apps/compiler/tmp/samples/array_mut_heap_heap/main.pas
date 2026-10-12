program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut2 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TMut2 = class l0: THeap1; end;
  TArray0 = array of TMut2;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function MutCreate2(a0: THeap1): TMut2;
begin
  Result := TMut2.Create; Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: TMut2;
  v6: TArray0;
  tmp7: TArray0;
  v7: LongInt;
  v8: AnsiString;
  v9: THeap0;
  v10: LongInt;
  v11: THeap1;
  v12: TMut2;
  v13: THeap1;
  v14: THeap0;
  v15: LongInt;
  v16: LongInt;
  v17: AnsiString;
  v18: Boolean;
  v20: Boolean;
  v19: Boolean;
  v22: Boolean;
  v21: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := MutCreate2(v4);
  tmp7 := nil;
  SetLength(tmp7, 1);
  v6 := tmp7;
  v6[0] := v5;
  v7 := 7;
  v8 := 'hi';
  v9 := HeapCreate0(v7, v8);
  v10 := 4;
  v11 := HeapCreate1(v9, v10);
  v12 := v6[0];
  v12.l0 := v11;
  v13 := v12.l0;
  v14 := v13.l0;
  v15 := v13.l1;
  v16 := v14.l0;
  v17 := v14.l1;
  v18 := v16 = 7;
  if v18 then begin
      v19 := v17 = 'hi';
      v20 := v19;
  end else begin
      v20 := False;
  end;
  if v20 then begin
      v21 := v15 = 4;
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
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
