program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TTuple0 = record f0: TArray0; f1: LongInt; end;
function method0: TTuple0; forward;
function method1(v0: TArray0; v1: LongInt): LongInt; forward;
function TupleCreate0(f0: TArray0; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0: TTuple0;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 4;
  v1[1] := 5;
  Result := TupleCreate0(v1, 1);
end;
function method1(v0: TArray0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v2 := v0[0];
  v3 := v0[1];
  v4 := v2 + v3;
  v5 := v4 + v1;
  v6 := v5 - 10;
  Result := v6;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  v1: LongInt;
  tmp2: TTuple0;
begin
  tmp2 := method0;
  v0 := tmp2.f0;
  v1 := tmp2.f1;
  Result := method1(v0, v1);
end;
begin
  Halt(SpiralMain);
end.
