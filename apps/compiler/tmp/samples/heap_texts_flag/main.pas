program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
  THeap0 = record l0: TArray0; l1: Boolean; end;
function HeapCreate0(a0: TArray0; a1: Boolean): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: Boolean;
  v3: THeap0;
  v4: TArray0;
  v5: Boolean;
  v6: AnsiString;
  v7: Boolean;
  v8: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := 'hi';
  v0[0] := v1;
  v2 := True;
  v3 := HeapCreate0(v0, v2);
  v4 := v3.l0;
  v5 := v3.l1;
  v6 := v4[0];
  v7 := v6 = 'hi';
  v8 := v7 and v5;
  if v8 then begin
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
