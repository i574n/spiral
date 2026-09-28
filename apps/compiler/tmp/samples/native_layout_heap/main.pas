program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Heap0 = class
    RefCount: LongInt;
    v0: LongInt;
    v1: LongInt;
  end;

function HeapCreate0(v0: LongInt; v1: LongInt): Heap0;
begin
  Result := Heap0.Create;
  Result.RefCount := 1;
  Result.v0 := v0;
  Result.v1 := v1;
end;
function HeapGet0_0(value: Heap0): LongInt;
begin
  Result := value.v0;
end;
function HeapGet0_1(value: Heap0): LongInt;
begin
  Result := value.v1;
end;
procedure HeapDecref0(var value: Heap0);
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then value.Free;
  value := nil;
end;

function SpiralMain: LongInt;
var
  v0: Heap0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := HeapCreate0(9, 10);
  v1 := HeapGet0_0(v0);
  v2 := HeapGet0_1(v0);
  HeapDecref0(v0);
  v3 := (v1 + v2);
  Exit(v3);
end;

begin
  Halt(SpiralMain);
end.
