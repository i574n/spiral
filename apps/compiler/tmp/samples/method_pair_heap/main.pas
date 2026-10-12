program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; end;
  TTuple0 = record f0: THeap0; f1: THeap0; end;
function method0(v0: THeap0; v1: THeap0): TTuple0; forward;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function TupleCreate0(f0: THeap0; f1: THeap0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: THeap0; v1: THeap0): TTuple0;
begin
  Result := TupleCreate0(v0, v1);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: THeap0;
  v3: THeap0;
  v4: THeap0;
  v5: THeap0;
  tmp6: TTuple0;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := HeapCreate0(v0);
  v3 := HeapCreate0(v1);
  tmp6 := method0(v2, v3);
  v4 := tmp6.f0;
  v5 := tmp6.f1;
  v6 := v4.l0;
  v7 := v5.l0;
  v8 := v6 + v7;
  v9 := v8 = 7;
  if v9 then begin
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
