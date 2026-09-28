program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0)  function Invoke(v0: LongInt): LongInt; override; end;
function ClosureCreate0: TFun0; forward;
function TClosure0.Invoke(v0: LongInt): LongInt;
var
  v1: LongInt;
begin
  v1 := v0 + 2;
  Result := v1;
end;
function ClosureCreate0: TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; 
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := ClosureCreate0;
  v1 := v0.Invoke(19);
  v2 := v0.Invoke(19);
  v3 := v1 + v2;
  Result := v3;
end;
begin
  Halt(SpiralMain);
end.
