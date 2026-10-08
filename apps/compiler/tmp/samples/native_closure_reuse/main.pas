program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0; forward;
function TClosure0.Invoke(v2: LongInt): LongInt;
var
  v3: LongInt;
  v4: LongInt;
begin
  v3 := v0 + v1;
  v4 := v3 + v2;
  Result := v4;
end;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := ClosureCreate0(v0, v1);
  v3 := v2.Invoke(10);
  v4 := v2.Invoke(20);
  v5 := v2.Invoke(3);
  v6 := v3 + v4;
  v7 := v6 + v5;
  Result := v7;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
