program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TTuple0 = record f0: TArray0; f1: TArray0; end;
procedure method0(v0: TArray0); forward;
function method1(v0: TArray0): LongInt; forward;
function method2(v0: TArray0): TTuple0; forward;
function method5(v0: TArray0; v1: TArray0): LongInt; forward;
function method4(v0: TArray0; v1: TArray0): LongInt; forward;
function method3(v0: TArray0; v1: TArray0): LongInt; forward;
function method6(v0: TArray0): LongInt; forward;
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
  v1 := DynamicArrayRefCount0(v0);
  Result := v1;
end;
function TupleCreate0(f0: TArray0; f1: TArray0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method2(v0: TArray0): TTuple0;
begin
  Result := TupleCreate0(v0, v0);
end;
function method5(v0: TArray0; v1: TArray0): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v2 := DynamicArrayRefCount0(v0);
  v3 := v1[0];
  v4 := v2 + v3;
  v5 := v0[0];
  v6 := v4 + v5;
  Result := v6;
end;
function method4(v0: TArray0; v1: TArray0): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := DynamicArrayCapacity0(v1);
  v3 := method5(v0, v1);
  v4 := v2 + v3;
  Result := v4;
end;
function method3(v0: TArray0; v1: TArray0): LongInt;
begin
  Result := method4(v1, v0);
end;
function method6(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: TArray0;
  v4: TArray0;
  tmp6: TTuple0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := 1;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 7;
  method0(v1);
  v2 := method1(v1);
  tmp6 := method2(v1);
  v3 := tmp6.f0;
  v4 := tmp6.f1;
  v5 := method3(v3, v4);
  v6 := method6(v1);
  v7 := v5 + v2;
  v8 := v7 + v6;
  v9 := v8 - 29;
  Result := v9;
end;
begin
  Halt(SpiralMain);
end.
