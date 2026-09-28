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
  TClosure1 = class(TFun0)  function Invoke(v0: LongInt): LongInt; override; end;
function ClosureCreate0: TFun0; forward;
function ClosureCreate1: TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
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
function TClosure1.Invoke(v0: LongInt): LongInt;
var
  v1: LongInt;
begin
  v1 := v0 + 3;
  Result := v1;
end;
function ClosureCreate1: TFun0;
var c: TClosure1;
begin
  c := TClosure1.Create; 
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(40);
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v3: TFun0;
begin
  v0 := True;
  if v0 then begin
      v3 := ClosureCreate0;
  end else begin
      v3 := ClosureCreate1;
  end;
  Result := method0(v3);
end;
begin
  Halt(SpiralMain);
end.
