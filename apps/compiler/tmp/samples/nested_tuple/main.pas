program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; f2: LongInt; f3: LongInt; end;
function method0(v0: LongInt): TTuple0; forward;
function method1(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongInt; f2: LongInt; f3: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2; Result.f3 := f3;
end;
function method0(v0: LongInt): TTuple0;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := v0 + 1;
  v2 := v0 + 2;
  v3 := v0 + 3;
  Result := TupleCreate0(v0, v1, v2, v3);
end;
function method1(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): LongInt;
var
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v4 := v0 + v1;
  v5 := v4 + v2;
  v6 := v5 + v3;
  v7 := v6 - 10;
  Result := v7;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  tmp5: TTuple0;
begin
  v0 := 1;
  tmp5 := method0(v0);
  v1 := tmp5.f0;
  v2 := tmp5.f1;
  v3 := tmp5.f2;
  v4 := tmp5.f3;
  Result := method1(v1, v2, v3, v4);
end;
begin
  Halt(SpiralMain);
end.
