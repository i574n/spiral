program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  THeap0 = record l0: TArray0; end;
function HeapCreate0(a0: TArray0): THeap0;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: THeap0;
  v4: TArray0;
  v5: LongInt;
  v6: Boolean;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v2 := 7;
  v1[0] := v2;
  v3 := HeapCreate0(v1);
  v4 := v3.l0;
  v5 := v4[0];
  v6 := v5 = 7;
  if v6 then begin
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
