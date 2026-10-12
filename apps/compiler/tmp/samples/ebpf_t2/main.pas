program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; end;
  TTuple1 = record f0: LongInt; f1: LongInt; f2: LongInt; end;
function method1(v0: LongInt; v1: LongInt): TTuple0; forward;
function method0(v0: LongInt; v1: LongInt): LongInt; forward;
function method3(v0: LongInt; v1: LongInt; v2: LongInt): TTuple1; forward;
function method2(v0: LongInt; v1: LongInt; v2: LongInt): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method1(v0: LongInt; v1: LongInt): TTuple0;
begin
  Result := TupleCreate0(v0, v1);
end;
function method0(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  tmp2: TTuple0;
  v4: LongInt;
begin
  tmp2 := method1(v0, v1);
  v2 := tmp2.f0;
  v3 := tmp2.f1;
  v4 := v2 + v3;
  Result := v4;
end;
function TupleCreate1(f0: LongInt; f1: LongInt; f2: LongInt): TTuple1;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method3(v0: LongInt; v1: LongInt; v2: LongInt): TTuple1;
begin
  Result := TupleCreate1(v0, v1, v2);
end;
function method2(v0: LongInt; v1: LongInt; v2: LongInt): LongInt;
var
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  tmp3: TTuple1;
  v6: LongInt;
  v7: LongInt;
begin
  tmp3 := method3(v0, v1, v2);
  v3 := tmp3.f0;
  v4 := tmp3.f1;
  v5 := tmp3.f2;
  v6 := v3 + v4;
  v7 := v6 + v5;
  Result := v7;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := 3;
  v3 := method0(v0, v1);
  v4 := method2(v0, v1, v2);
  v5 := v3 + v4;
  v6 := v5 - 9;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
