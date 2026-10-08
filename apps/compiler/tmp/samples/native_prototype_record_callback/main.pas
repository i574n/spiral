program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TTuple0 = record f0: LongInt; f1: LongInt; end;
  TFun0 = class
    function Invoke(a0: LongInt; a1: LongInt): TTuple0; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt; v2: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function method0(v0: TFun0): TTuple0; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function TClosure0.Invoke(v1: LongInt; v2: LongInt): TTuple0;
var
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v3 := v1 - 8;
  v4 := v3 + v0;
  v5 := v2 - 18;
  Result := TupleCreate0(v4, v5);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0): TTuple0;
begin
  Result := v0.Invoke(10, 20);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: LongInt;
  v3: LongInt;
  tmp4: TTuple0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 1;
  v1 := ClosureCreate0(v0);
  tmp4 := method0(v1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := 10 + v2;
  v5 := 20 + v3;
  v6 := v4 + v5;
  v7 := v6 + 7;
  Result := v7;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
