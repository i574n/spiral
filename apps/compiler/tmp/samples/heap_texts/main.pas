program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
  THeap0 = record l0: TArray0; end;
function HeapCreate0(a0: TArray0): THeap0;
begin
  Result.l0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: THeap0;
  v3: TArray0;
  v4: AnsiString;
  v5: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v0 := tmp1;
  v1 := 'hi';
  v0[0] := v1;
  v2 := HeapCreate0(v0);
  v3 := v2.l0;
  v4 := v3[0];
  v5 := v4 = 'hi';
  if v5 then begin
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
