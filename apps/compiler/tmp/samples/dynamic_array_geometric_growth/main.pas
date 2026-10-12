program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
procedure method0(v0: TArray0); forward;
function method1(v0: TArray0): LongInt; forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayReserve0(v0,v1);
end;
function method1(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: LongInt;
  v2: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 0);
  v0 := tmp1;
  method0(v0);
  v1 := method1(v0);
  v2 := v1 - 4;
  Result := v2;
end;
begin
  Halt(SpiralMain);
end.
